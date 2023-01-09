using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TrProtocol.Models;
using TrProtocol.Serializers;

namespace TrProtocol
{
    public partial class PacketSerializer
    {
        private class LegacySerializer : IFieldSerializer
        {
            private Serializer serializer;
            private Deserializer deserializer;
            private Type type;

            public LegacySerializer(Serializer serializer, Deserializer deserializer, Type type)
            {
                this.serializer = serializer;
                this.deserializer = deserializer;
                this.type = type;
            }

            public object Read(BinaryReader br)
            {
                var o = Activator.CreateInstance(type);
                deserializer(o, br);
                return o;
            }

            public void Write(BinaryWriter bw, object o)
            {
                serializer(o, bw);
            }
        }

        private delegate void Serializer(object o, BinaryWriter bw);
        private delegate void Deserializer(object o, BinaryReader br);

        private readonly Dictionary<Type, Action<BinaryWriter, Packet>> serializers = new();

        private readonly Dictionary<MessageID, Func<BinaryReader, Packet>> deserializers = new();
        private readonly Dictionary<NetModuleType, Func<BinaryReader, NetModulesPacket>> moduledeserializers = new();

        private readonly Dictionary<Type, Type> enumSerializers = new()
        {
            [typeof(short)] = typeof(ShortEnumSerializer<>),
            [typeof(byte)] = typeof(ByteEnumSerializer<>)
        };

        private readonly ArraySerializer arraySerializer = new();
        private void LoadPackets(Assembly asm)
        {
            foreach (var type in asm.GetTypes())
            {
                RegisterPacket(type);
            }
        }

        public void RegisterPacket<T>() where T : Packet
        {
            RegisterPacket(typeof(T));
        }

        private (Serializer, Deserializer) GenerateSerializers(Type type)
        {
            Serializer serializer = null;
            Deserializer deserializer = null;

            var dict = new Dictionary<string, PropertyInfo>();
            var empty = Array.Empty<object>();

            foreach (var (prop, flag) in
                type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Select(p => (p, BindingFlags.NonPublic))
                    .Concat(type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => (p, BindingFlags.Public))))
            {
                dict.Add(prop.Name, prop);

                if (prop.IsDefined(typeof(IgnoreAttribute))) continue;
                if (flag == BindingFlags.NonPublic && !prop.IsDefined(typeof(ForceSerializeAttribute))) continue;

                var ver = prop.GetCustomAttribute<ProtocolVersionAttribute>();
                if (ver != null && ver.version != this.version) continue;

                var get = prop.GetMethod;
                var set = prop.SetMethod;
                var t = prop.PropertyType;

                Func<object, bool> condition = _ => true;

                var cond = prop.GetCustomAttribute<ConditionAttribute>();

                var shouldSerialize = (client
                    ? (object)prop.GetCustomAttribute<S2COnlyAttribute>()
                    : prop.GetCustomAttribute<C2SOnlyAttribute>()) == null;
                var shouldDeserialize = (!client
                    ? (object)prop.GetCustomAttribute<S2COnlyAttribute>()
                    : prop.GetCustomAttribute<C2SOnlyAttribute>()) == null && set != null;

                if (cond != null)
                {
                    var get2 = dict[cond.field].GetMethod;
                    if (cond.bit == -1)
                        condition = o => ((bool)get2.Invoke(o, empty));
                    else
                        condition = o => ((BitsByte)get2.Invoke(o, empty))[cond.bit] == cond.pred;
                }

                IFieldSerializer ser;

                foreach (var attr in t.GetCustomAttributes<SerializerAttribute>())
                {
                    if ((attr.version ?? version) == version)
                    {
                        ser = attr.serializer;
                        goto serFound;
                    }
                }

                if (t.BaseType == typeof(Enum))
                {
                    var genrericType = enumSerializers[t.GetFields()[0].FieldType];
                    var seriliazer = genrericType.MakeGenericType(t);
                    ser = (IFieldSerializer)Activator.CreateInstance(seriliazer);
                }
                else if (t.IsDefined(typeof(LegacySerializerAttribute)))
                {
                    var (s, ds) = GenerateSerializers(type);
                    ser = new LegacySerializer(s, ds, t);
                }
                else if (!fieldSerializers.TryGetValue(t, out ser))
                {
                    if (t.IsAssignableTo(typeof(Array)))
                        ser = arraySerializer;
                    else
                        throw new Exception("No valid serializer for type: " + t.FullName);
                }

            serFound:

                if (ser is IConfigurable conf) ser = conf.Configure(prop, version, name => (o => dict[name].GetValue(o)));
                var cfg = ser as IInstanceConfigurable;

                if (shouldSerialize)
                    serializer += (o, bw) =>
                    {
                        if (condition(o))
                        {
                            cfg?.Configure(prop, version, o);
                            ser.Write(bw, get.Invoke(o, empty));
                        }
                    };
                if (shouldDeserialize)
                    deserializer += (o, br) =>
                    {
                        if (condition(o))
                        {
                            cfg?.Configure(prop, version, o);
                            set.Invoke(o, new[] { ser.Read(br) });
                        }
                    };
            }

            return (serializer, deserializer);
        }

        private void RegisterPacket(Type type)
        {
            if (type.IsAbstract || !type.IsSubclassOf(typeof(Packet))) return;

            var inst = Activator.CreateInstance(type);
            var (serializer, deserializer) = GenerateSerializers(type);

            if (client ? (type.GetCustomAttribute<S2COnlyAttribute>() == null) : (type.GetCustomAttribute<C2SOnlyAttribute>()) == null)
                serializers[type] = (bw, o) => serializer?.Invoke(o, bw);

            if ((!client) ? (type.GetCustomAttribute<S2COnlyAttribute>() == null) : (type.GetCustomAttribute<C2SOnlyAttribute>()) == null)
            {
                if (inst is NetModulesPacket p)
                {
                    moduledeserializers.Add(p.ModuleType, br =>
                    {
                        var result = Activator.CreateInstance(type) as NetModulesPacket;
                        deserializer?.Invoke(result, br);
                        return result;
                    });
                }
                else if (inst is Packet p2)
                {
                    deserializers.Add(p2.Type, br =>
                    {
                        var result = Activator.CreateInstance(type) as Packet;
                        deserializer?.Invoke(result, br);
                        return result;
                    });
                }
            }
        }

        private readonly bool client;
        private readonly string version;


        public PacketSerializer(bool client, string version = "Terraria242")
        {
            this.client = client;
            this.version = version;
            LoadPackets(Assembly.GetExecutingAssembly());
        }

        public Packet Deserialize(BinaryReader br0)
        {
            var l = br0.ReadInt16();
            using var ms = new MemoryStream(br0.ReadBytes(l - 2));
            using var br = new BinaryReader(ms);
            Packet result = null;
            var msgid = (MessageID)br.ReadByte();
            if (msgid == MessageID.NetModules)
            {
                var moduletype = (NetModuleType)br.ReadInt16();
                if (moduledeserializers.TryGetValue(moduletype, out var f))
                    result = f(br);
                else
                    Console.WriteLine($"[Warning] net module type = {moduletype} not defined, ignoring");
            }
            else if (deserializers.TryGetValue(msgid, out var f2))
                result = f2(br);
            else
                Console.WriteLine($"[Warning] message type = {msgid} not defined, ignoring");

            if (br.BaseStream.Position != br.BaseStream.Length)
            {
                Console.WriteLine($"[Warning] {br.BaseStream.Length - br.BaseStream.Position} not used when deserializing {(client ? "S2C::" : "C2S::")}{result}");
            }
            return result;
        }

        public byte[] Serialize(Packet p)
        {
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);
            bw.Write((short)0);

            if (serializers.TryGetValue(p.GetType(), out var f))
            {
                f(bw, p);
                var l = bw.BaseStream.Position;
                bw.BaseStream.Position = 0;
                bw.Write((short)l);
                return ms.ToArray();
            }

            Console.WriteLine($"[Warning] packet {p} not defined, ignoring");
            return Array.Empty<byte>();
        }

    }
}

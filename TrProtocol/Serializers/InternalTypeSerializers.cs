using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TrProtocol
{
    public partial class PacketSerializer
    {
        static PacketSerializer()
        {
            RegisterSerializer(new GuidSerializer());
            RegisterSerializer(new BoolSerializer());
            RegisterSerializer(new ByteSerializer());
            RegisterSerializer(new SByteSerializer());
            RegisterSerializer(new ShortSerializer());
            RegisterSerializer(new UShortSerializer());
            RegisterSerializer(new IntSerializer());
            RegisterSerializer(new UIntSerializer());
            RegisterSerializer(new LongSerializer());
            RegisterSerializer(new ULongSerializer());
            RegisterSerializer(new FloatSerializer());
            RegisterSerializer(new StringSerializer());

            RegisterSerializer(new ArraySerializer());
            RegisterSerializer(new ByteArraySerializer());
        }

        private static readonly Dictionary<Type, IFieldSerializer> fieldSerializers = new();
        private static void RegisterSerializer<T>(FieldSerializer<T> serializer)
        {
            fieldSerializers.Add(typeof(T), serializer);
        }

        private class GuidSerializer : FieldSerializer<Guid>
        {
            protected override Guid _Read(BinaryReader br) => new(br.ReadBytes(16));
            protected override void _Write(BinaryWriter bw, Guid t) => bw.Write(t.ToByteArray());
        }

        private class BoolSerializer : FieldSerializer<bool>
        {
            protected override bool _Read(BinaryReader br) => br.ReadBoolean();
            protected override void _Write(BinaryWriter bw, bool t) => bw.Write(t);
        }
        private class ByteSerializer : NumFieldSerializer<byte>
        {
            protected override byte _Read(BinaryReader br) => br.ReadByte();
            protected override void _Write(BinaryWriter bw, byte t) => bw.Write(t);
        }
        private class SByteSerializer : NumFieldSerializer<sbyte>
        {
            protected override sbyte _Read(BinaryReader br) => br.ReadSByte();
            protected override void _Write(BinaryWriter bw, sbyte t) => bw.Write(t);
        }
        private class ShortSerializer : NumFieldSerializer<short>
        {
            protected override short _Read(BinaryReader br) => br.ReadInt16();
            protected override void _Write(BinaryWriter bw, short t) => bw.Write(t);
        }
        private class UShortSerializer : NumFieldSerializer<ushort>
        {
            protected override ushort _Read(BinaryReader br) => br.ReadUInt16();
            protected override void _Write(BinaryWriter bw, ushort t) => bw.Write(t);
        }
        private class IntSerializer : NumFieldSerializer<int>
        {
            protected override int _Read(BinaryReader br) => br.ReadInt32();
            protected override void _Write(BinaryWriter bw, int t) => bw.Write(t);
        }
        private class UIntSerializer : NumFieldSerializer<uint>
        {
            protected override uint _Read(BinaryReader br) => br.ReadUInt32();
            protected override void _Write(BinaryWriter bw, uint t) => bw.Write(t);
        }
        private class LongSerializer : FieldSerializer<long>
        {
            protected override long _Read(BinaryReader br) => br.ReadInt64();
            protected override void _Write(BinaryWriter bw, long t) => bw.Write(t);
        }
        private class ULongSerializer : FieldSerializer<ulong>
        {
            protected override ulong _Read(BinaryReader br) => br.ReadUInt64();
            protected override void _Write(BinaryWriter bw, ulong t) => bw.Write(t);
        }

        private class FloatSerializer : FieldSerializer<float>
        {
            protected override float _Read(BinaryReader br) => br.ReadSingle();
            protected override void _Write(BinaryWriter bw, float t) => bw.Write(t);
        }

        private class StringSerializer : FieldSerializer<string>
        {
            protected override string _Read(BinaryReader br) => br.ReadString();
            protected override void _Write(BinaryWriter bw, string t) => bw.Write(t);
        }

        private class ByteArraySerializer : FieldSerializer<byte[]>
        {
            protected override byte[] _Read(BinaryReader br)
            {
                return br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
            }

            protected override void _Write(BinaryWriter bw, byte[] t)
            {
                bw.Write(t);
            }
        }

        private class ArraySerializer : FieldSerializer<Array>, IConfigurable, IInstanceConfigurable
        {
            private readonly Func<object, int>[] sizeGetter;
            private readonly int[] size;
            private readonly IFieldSerializer @base;
            private readonly Type type;

            public ArraySerializer()
            {

            }

            private ArraySerializer(Type type, params Func<object, int>[] sizeGetter)
            {
                this.sizeGetter = sizeGetter;
                this.size = new int[sizeGetter.Length];
                @base = fieldSerializers[type];
                this.type = type;
            }

            protected override Array _Read(BinaryReader br)
            {
                var t = Array.CreateInstance(type, size);
                var n = size.Length;
                var s = t.Length;
                var i = new int[n];
                while (--s >= 0)
                {
                    t.SetValue(@base.Read(br), i);
                    var k = n - 1;
                    ++i[k];
                    while (i[k] == t.GetLength(k))
                    {
                        i[k] = 0;
                        ++i[--k];
                    }
                }
                return t;
            }

            protected override void _Write(BinaryWriter bw, Array t)
            {
                foreach (var x in t)
                    @base.Write(bw, x);
            }

            public IFieldSerializer Configure(PropertyInfo prop, string version, Func<string, Func<object, object>> valGetter)
            {
                if (@base is IConfigurable conf) conf.Configure(prop, version, valGetter);
                return new ArraySerializer(prop.PropertyType, prop.GetCustomAttribute<ArraySizeAttribute>().size
                    .Select<object, Func<object, int>>(o => o switch
                {
                    string s => (o => ((int)Convert.ChangeType(valGetter(s)(o), typeof(int)))),
                    int i  => (_ => i),
                    _ => (_ => 1)
                }).ToArray());
            }

            public void Configure(PropertyInfo prop, string version, object @base)
            {
                for (int i = 0; i < sizeGetter.Length; ++i)
                    size[i] = sizeGetter[i](@base);
            }
        }
    }
}
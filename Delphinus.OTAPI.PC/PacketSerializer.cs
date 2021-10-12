using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Delphinus
{
    public partial class PacketSerializer
    {
        private static readonly Dictionary<byte, Type> packets = new Dictionary<byte, Type>();
        private static readonly Dictionary<ushort, Type> modules = new Dictionary<ushort, Type>();

        private readonly bool client;

        public PacketSerializer(bool client)
        {
            this.client = client;
        }

        public Packet Deserialize(BinaryReader br0)
        {
            var l = br0.ReadInt16();
            using (var ms = new MemoryStream(br0.ReadBytes(l - 2)))
            using (var br = new BinaryReader(ms))
            {
                Type packet = null;
                var msgid = br.ReadByte();
                if (msgid == 82)
                {
                    var moduletype = br.ReadUInt16();
                    if (!modules.TryGetValue(moduletype, out packet))
                    {
                        Console.WriteLine($"[Warning] net module type = {moduletype} not defined, ignoring");
                        return null;
                    }
                }
                else if (!packets.TryGetValue(msgid, out packet))
                {
                    Console.WriteLine($"[Warning] message type = {msgid} not defined, ignoring");
                    return null;
                }

                var result = (Packet)Activator.CreateInstance(packet);
                result.Deserialize(br, client);
                if (br.BaseStream.Position != br.BaseStream.Length)
                {
                    Console.WriteLine($"[Warning] {br.BaseStream.Length - br.BaseStream.Position} not used when deserializing {(client ? "S2C::" : "C2S::")}{result}");
                }
                return result;
            }
        }

        public byte[] Serialize(Packet p)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write((short)0);
                p.Serialize(bw, client);
                var l = bw.BaseStream.Position;
                bw.BaseStream.Position = 0;
                bw.Write((short)l);
                return ms.ToArray();
            }
        }

    }
}

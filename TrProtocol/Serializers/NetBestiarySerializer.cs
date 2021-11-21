using System.IO;

namespace TrProtocol.Models
{
    [Serializer(typeof(NetBestiarySerializer))]
    public partial class NetBestiary
    {
        private class NetBestiarySerializer : FieldSerializer<NetBestiary>
        {
            protected override NetBestiary _Read(BinaryReader br)
            {
                var bestiary = new NetBestiary
                {
                    UnlockType = (BestiaryUnlockType)br.ReadByte(),
                    NPCNetID = br.ReadInt16()
                };
                if (bestiary.UnlockType == BestiaryUnlockType.Kill)
                    bestiary.KillCount = br.ReadUInt16();
                return bestiary;
            }

            protected override void _Write(BinaryWriter bw, NetBestiary t)
            {
                bw.Write((byte)t.UnlockType);
                bw.Write(t.NPCNetID);
                if (t.UnlockType == BestiaryUnlockType.Kill)
                    bw.Write(t.KillCount);
            }
        }
    }
}

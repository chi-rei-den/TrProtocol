using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    [Manual]
    internal class SyncNPCPacket : IPacket
    {
        public MessageID Type => MessageID.SyncNPC;

        public short NPCSlot { get; set; }

        public Vector2 Offset { get; set; }
        public Vector2 Velocity { get; set; }
        public ushort Target { get; set; }

        public BitsByte Flags1 { get; set; }
        public BitsByte Flags2 { get; set; }

        public float AI1 { get; set; }
        public float AI2 { get; set; }
        public float AI3 { get; set; }
        public float AI4 { get; set; }

        public short NPCNetID { get; set; }

        public byte PlayerCountOverride { get; set; }
        public float StrengthMultiplier { get; set; }
        public BitsByte Bit3 { get; set; }
        public sbyte PrettyShortHP { get; set; }
        public short ShortHP { get; set; }
        public int HP { get; set; }
        public byte[] Extra { get; set; }
    }
}
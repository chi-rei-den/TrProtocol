namespace Delphinus.InternalPackets
{
    internal class AddNPCBuff : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public ushort BuffType { get; set; }
        public short BuffTime { get; set; }
    }
}
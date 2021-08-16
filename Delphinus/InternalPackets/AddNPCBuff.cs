namespace Delphinus.InternalPackets
{
    internal class AddNPCBuffPacket : IPacket, INPCSlot
    {
        public MessageID Type => MessageID.AddNPCBuff;
        public short NPCSlot { get; set; }
        public ushort BuffType { get; set; }
        public short BuffTime { get; set; }
    }
}
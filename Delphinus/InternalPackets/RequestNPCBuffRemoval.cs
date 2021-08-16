namespace Delphinus.InternalPackets
{
    internal class RequestNPCBuffRemovalPacket : IPacket, INPCSlot
    {
        public MessageID Type => MessageID.RequestNPCBuffRemoval;
        public short NPCSlot { get; set; }
        public ushort BuffType { get; set; }
    }
}
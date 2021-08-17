namespace Delphinus.InternalPackets
{
    internal class RequestNPCBuffRemoval : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public ushort BuffType { get; set; }
    }
}
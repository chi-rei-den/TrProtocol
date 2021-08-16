namespace Delphinus.InternalPackets
{
    internal class RemoveRevengeMarkerPacket : IPacket
    {
        public MessageID Type => MessageID.RemoveRevengeMarker;
        public int ID { get; set; }
    }
}
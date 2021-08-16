namespace Delphinus.InternalPackets
{
    internal class RequestTileEntityInteractionPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.RequestTileEntityInteraction;
        public int TileEntityID { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
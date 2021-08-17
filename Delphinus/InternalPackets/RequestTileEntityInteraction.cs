namespace Delphinus.InternalPackets
{
    internal class RequestTileEntityInteraction : IPacket, IPlayerSlot
    {
        public int TileEntityID { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
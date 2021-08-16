namespace Delphinus.InternalPackets
{
    internal class TileEntityPlacementPacket : IPacket
    {
        public MessageID Type => MessageID.TileEntityPlacement;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte TileEntityType { get; set; }
    }
}
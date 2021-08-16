namespace Delphinus.InternalPackets
{
    internal class PaintTilePacket : IPacket
    {
        public MessageID Type => MessageID.PaintTile;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte Color { get; set; }
    }
}
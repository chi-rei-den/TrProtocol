namespace Delphinus.InternalPackets
{
    internal class PaintTile : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte Color { get; set; }
    }
}
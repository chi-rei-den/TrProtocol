namespace Delphinus.InternalPackets
{
    internal class PaintWallPacket : IPacket
    {
        public MessageID Type => MessageID.PaintWall;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte Color { get; set; }
    }
}
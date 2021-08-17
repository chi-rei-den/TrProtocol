namespace Delphinus.InternalPackets
{
    internal class FrameSection : IPacket
    {
        public short StartX { get; set; }
        public short StartY { get; set; }
        public short EndX { get; set; }
        public short EndY { get; set; }
    }
}

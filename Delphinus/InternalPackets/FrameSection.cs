namespace Delphinus.InternalPackets
{
    internal class FrameSectionPacket : IPacket
    {
        public MessageID Type => MessageID.FrameSection;
        public short StartX { get; set; }
        public short StartY { get; set; }
        public short EndX { get; set; }
        public short EndY { get; set; }
    }
}

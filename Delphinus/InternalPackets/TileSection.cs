namespace Delphinus.InternalPackets
{
    internal class TileSectionPacket : IPacket
    {
        public MessageID Type => MessageID.TileSection;
        public byte[] Data { get; set; }
    }
}

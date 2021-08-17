namespace Delphinus.InternalPackets
{
    internal class TileSectionPacket : IPacket
    {
        public MessageID Type => MessageID.TileSection;
        //TODO
        // public byte[] Data { get; set; }
    }
}

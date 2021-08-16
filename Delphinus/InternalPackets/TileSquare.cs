namespace Delphinus.InternalPackets
{
    internal class TileSquarePacket : IPacket
    {
        public MessageID Type => MessageID.TileSquare;
        public byte[] Data { get; set; }
    }
}

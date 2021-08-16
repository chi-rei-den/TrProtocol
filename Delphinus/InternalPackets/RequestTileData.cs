namespace Delphinus.InternalPackets
{
    internal class RequestTileDataPacket : IPacket
    {
        public MessageID Type => MessageID.RequestTileData;
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}

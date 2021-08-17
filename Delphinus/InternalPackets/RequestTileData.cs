namespace Delphinus.InternalPackets
{
    internal class RequestTileData : IPacket
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}

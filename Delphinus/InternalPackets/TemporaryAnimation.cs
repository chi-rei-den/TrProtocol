namespace Delphinus.InternalPackets
{
    internal class TemporaryAnimation : IPacket
    {
        public short AniType { get; set; }
        public short TileType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
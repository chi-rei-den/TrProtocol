namespace Delphinus.InternalPackets
{
    internal class TemporaryAnimationPacket : IPacket
    {
        public MessageID Type => MessageID.TemporaryAnimation;
        public short AniType { get; set; }
        public short TileType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
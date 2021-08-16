namespace Delphinus.InternalPackets
{
    internal class TileChangePacket : IPacket
    {
        public MessageID Type => MessageID.TileChange;
        public byte ChangeType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short TileType { get; set; }
        public byte Style { get; set; }
    }
}

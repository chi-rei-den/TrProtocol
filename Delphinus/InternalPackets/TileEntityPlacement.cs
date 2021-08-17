namespace Delphinus.InternalPackets
{
    internal class TileEntityPlacement : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte TileEntityType { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class Unlock : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
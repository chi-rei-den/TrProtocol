namespace Delphinus.InternalPackets
{
    internal class GemLockToggle : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
        public bool Flag { get; set; }
    }
}
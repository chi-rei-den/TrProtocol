namespace Delphinus.InternalPackets
{
    internal class FishOutNPC : IPacket
    {
        public ushort PosX { get; set; }
        public ushort PosY { get; set; }
        public short Start { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class LandGolfBallInCup : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public ushort PosX { get; set; }
        public ushort PosY { get; set; }
        public ushort Hits { get; set; }
        public ushort ProjType { get; set; }
    }
}
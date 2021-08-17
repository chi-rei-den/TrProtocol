namespace Delphinus.InternalPackets
{
    internal class UpdatePlayerLuckFactors : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public int Time { get; set; }
        public float Luck { get; set; }
        public byte Potion { get; set; }
        public bool HasGardenGnomeNearby { get; set; }
    }
}
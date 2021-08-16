namespace Delphinus.InternalPackets
{
    internal class UpdatePlayerLuckFactorsPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.UpdatePlayerLuckFactors;
        public byte PlayerSlot { get; set; }
        public int Time { get; set; }
        public float Luck { get; set; }
        public byte Potion { get; set; }
        public bool HasGardenGnomeNearby { get; set; }
    }
}
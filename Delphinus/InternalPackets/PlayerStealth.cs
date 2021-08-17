namespace Delphinus.InternalPackets
{
    internal class PlayerStealth : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public float Stealth { get; set; }
    }
}
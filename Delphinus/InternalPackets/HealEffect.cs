namespace Delphinus.InternalPackets
{
    internal class HealEffect : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
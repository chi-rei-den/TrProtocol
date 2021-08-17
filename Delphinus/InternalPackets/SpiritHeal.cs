namespace Delphinus.InternalPackets
{
    internal class SpiritHeal : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
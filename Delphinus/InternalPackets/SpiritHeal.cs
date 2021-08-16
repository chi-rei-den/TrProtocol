namespace Delphinus.InternalPackets
{
    internal class SpiritHealPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.SpiritHeal;
        public byte OtherPlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
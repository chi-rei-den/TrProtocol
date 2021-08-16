namespace Delphinus.InternalPackets
{
    internal class HealEffectPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.HealEffect;
        public byte PlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
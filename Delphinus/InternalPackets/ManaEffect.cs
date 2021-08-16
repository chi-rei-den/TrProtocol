namespace Delphinus.InternalPackets
{
    internal class ManaEffectPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.ManaEffect;
        public byte PlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
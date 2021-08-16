namespace Delphinus.InternalPackets
{
    internal class ItemAnimationPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.ItemAnimation;
        public byte PlayerSlot { get; set; }
        public float Rotation { get; set; }
        public short Animation { get; set; }
    }
}
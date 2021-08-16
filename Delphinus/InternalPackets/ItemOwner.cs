namespace Delphinus.InternalPackets
{
    internal class ItemOwnerPacket : IPacket, IItemSlot, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.ItemOwner;
        public short ItemSlot { get; set; }
        public byte OtherPlayerSlot { get; set; }
    }
}

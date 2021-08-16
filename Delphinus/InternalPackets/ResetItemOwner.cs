namespace Delphinus.InternalPackets
{
    internal class ResetItemOwnerPacket : IPacket, IItemSlot
    {
        public MessageID Type => MessageID.ResetItemOwner;
        public short ItemSlot { get; set; }
    }
}
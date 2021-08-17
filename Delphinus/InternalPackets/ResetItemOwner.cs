namespace Delphinus.InternalPackets
{
    internal class ResetItemOwner : IPacket, IItemSlot
    {
        public short ItemSlot { get; set; }
    }
}
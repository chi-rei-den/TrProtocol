namespace Delphinus.InternalPackets
{
    internal class ItemOwner : IPacket, IItemSlot, IOtherPlayerSlot
    {
        public short ItemSlot { get; set; }
        public byte OtherPlayerSlot { get; set; }
    }
}

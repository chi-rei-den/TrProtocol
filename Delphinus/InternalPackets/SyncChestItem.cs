namespace Delphinus.InternalPackets
{
    internal class SyncChestItem : IPacket
    {
        public short ChestSlot { get; set; }
        public byte ChestItemSlot { get; set; }
        public short Stack { get; set; }
        public byte Prefix { get; set; }
        public short ItemType { get; set; }
    }
}
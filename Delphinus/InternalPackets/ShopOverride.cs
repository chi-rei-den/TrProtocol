using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class ShopOverridePacket : IPacket
    {
        public MessageID Type => MessageID.ShopOverride;
        public byte ItemSlot { get; set; }
        public short ItemType { get; set; }
        public short Stack { get; set; }
        public byte Prefix { get; set; }
        public int Value { get; set; }
        public BitsByte BuyOnce { get; set; } // only first bit counts
    }
}
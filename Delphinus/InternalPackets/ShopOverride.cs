using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class ShopOverride : IPacket
    {
        public byte ItemSlot { get; set; }
        public short ItemType { get; set; }
        public short Stack { get; set; }
        public byte Prefix { get; set; }
        public int Value { get; set; }
        public BitsByte BuyOnce { get; set; } // only first bit counts
    }
}
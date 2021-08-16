namespace Delphinus.InternalPackets
{
    internal class TravelMerchantItemsPacket : IPacket
    {
        public MessageID Type => MessageID.TravelMerchantItems;
        [ArraySize(40)] public short[] ShopItems { get; set; }
    }
}
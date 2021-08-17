namespace Delphinus.InternalPackets
{
    internal class TravelMerchantItemsPacket : IPacket
    {
        public MessageID Type => MessageID.TravelMerchantItems;
        [Arguments("40")]
        public short[] ShopItems { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class TravelMerchantItems : IPacket
    {
        [Arguments("40")]
        public short[] ShopItems { get; set; }
    }
}
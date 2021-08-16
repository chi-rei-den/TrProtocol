namespace Delphinus.InternalPackets
{
    internal class FoodPlatterTryPlacingPacket : IPacket
    {
        public MessageID Type => MessageID.FoodPlatterTryPlacing;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short ItemType { get; set; }
        public byte Prefix { get; set; }
        public short Stack { get; set; }
    }
}
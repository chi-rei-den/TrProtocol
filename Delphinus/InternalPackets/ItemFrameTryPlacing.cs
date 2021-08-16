namespace Delphinus.InternalPackets
{
    internal class ItemFrameTryPlacingPacket : IPacket
    {
        public MessageID Type => MessageID.ItemFrameTryPlacing;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short ItemType { get; set; }
        public byte Prefix { get; set; }
        public short Stack { get; set; }
    }
}
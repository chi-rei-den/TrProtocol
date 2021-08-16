namespace Delphinus.InternalPackets
{
    internal class WeaponsRackTryPlacingPacket : IPacket
    {
        public MessageID Type => MessageID.WeaponsRackTryPlacing;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short ItemType { get; set; }
        public byte Prefix { get; set; }
        public short Stack { get; set; }
    }
}
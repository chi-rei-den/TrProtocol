namespace Delphinus.InternalPackets
{
    internal class WeaponsRackTryPlacing : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short ItemType { get; set; }
        public byte Prefix { get; set; }
        public short Stack { get; set; }
    }
}
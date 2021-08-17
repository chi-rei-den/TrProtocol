namespace Delphinus.InternalPackets
{
    internal class RequestChestOpen : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
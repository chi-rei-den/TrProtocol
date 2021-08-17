namespace Delphinus.InternalPackets
{
    internal class RequestReadSign : IPacket
    {
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
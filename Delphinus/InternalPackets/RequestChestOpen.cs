namespace Delphinus.InternalPackets
{
    internal class RequestChestOpenPacket : IPacket
    {
        public MessageID Type => MessageID.RequestChestOpen;
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
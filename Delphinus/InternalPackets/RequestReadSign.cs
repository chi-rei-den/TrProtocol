namespace Delphinus.InternalPackets
{
    internal class RequestReadSignPacket : IPacket
    {
        public MessageID Type => MessageID.RequestReadSign;
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
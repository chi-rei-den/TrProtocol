namespace Delphinus.InternalPackets
{
    internal class RequestWorldInfoPacket : IPacket
    {
        public MessageID Type => MessageID.RequestWorldInfo;
    }
}

namespace Delphinus.InternalPackets
{
    internal class SocialHandshakePacket : IPacket
    {
        public MessageID Type => MessageID.SocialHandshake;
    }
}
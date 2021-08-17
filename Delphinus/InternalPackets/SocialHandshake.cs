namespace Delphinus.InternalPackets
{
    internal class SocialHandshakePacket : IPacket
    {
        public MessageID Type => MessageID.SocialHandshake;
        //TODO
        // public byte[] Raw { get; set; }
    }
}
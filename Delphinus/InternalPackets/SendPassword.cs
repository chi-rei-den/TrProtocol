namespace Delphinus.InternalPackets
{
    internal class SendPasswordPacket : IPacket
    {
        public MessageID Type => MessageID.SendPassword;
        public string Password { get; set; }
    }
}

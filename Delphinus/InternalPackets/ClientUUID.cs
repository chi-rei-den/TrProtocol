namespace Delphinus.InternalPackets
{
    internal class ClientUUIDPacket : IPacket
    {
        public MessageID Type => MessageID.ClientUUID;
        public string UUID { get; set; }
    }
}
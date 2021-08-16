namespace Delphinus.InternalPackets
{
    internal class FinishedConnectingToServerPacket : IPacket
    {
        public MessageID Type => MessageID.FinishedConnectingToServer;
    }
}
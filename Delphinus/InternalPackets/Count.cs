namespace Delphinus.InternalPackets
{
    internal class CountPacket : IPacket
    {
        public MessageID Type => MessageID.Count;
    }
}
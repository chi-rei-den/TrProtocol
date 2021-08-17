namespace Delphinus.InternalPackets
{
    internal class SyncEmoteBubblePacket : IPacket
    {
        public MessageID Type => MessageID.SyncEmoteBubble;
        public int ID { get; set; }

        public byte EmoteType { get; set; }

        //FIXME: Terrible Format, can't understand
        // public byte[] Raw { get; set; }
    }
}
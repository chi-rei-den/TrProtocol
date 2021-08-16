namespace Delphinus.InternalPackets
{
    internal class AnglerQuestFinishedPacket : IPacket
    {
        public MessageID Type => MessageID.AnglerQuestFinished;
    }
}
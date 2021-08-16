namespace Delphinus.InternalPackets
{
    internal class AnglerQuestPacket : IPacket
    {
        public MessageID Type => MessageID.AnglerQuest;
        public byte QuestType { get; set; }
        public bool Finished { get; set; }
    }
}
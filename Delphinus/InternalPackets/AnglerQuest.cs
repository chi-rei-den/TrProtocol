namespace Delphinus.InternalPackets
{
    internal class AnglerQuest : IPacket
    {
        public byte QuestType { get; set; }
        public bool Finished { get; set; }
    }
}
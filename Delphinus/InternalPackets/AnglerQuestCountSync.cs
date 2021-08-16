namespace Delphinus.InternalPackets
{
    internal class AnglerQuestCountSyncPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.AnglerQuestCountSync;
        public byte PlayerSlot { get; set; }
        public int AnglerQuestsFinished { get; set; }
        public int GolferScoreAccumulated { get; set; }
    }
}
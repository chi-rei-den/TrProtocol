namespace Delphinus.InternalPackets
{
    internal class AnglerQuestCountSync : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public int AnglerQuestsFinished { get; set; }
        public int GolferScoreAccumulated { get; set; }
    }
}
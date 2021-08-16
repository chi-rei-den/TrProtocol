namespace Delphinus.InternalPackets
{
    internal class AchievementMessageEventHappenedPacket : IPacket
    {
        public MessageID Type => MessageID.AchievementMessageEventHappened;
        public short EventType { get; set; }
    }
}
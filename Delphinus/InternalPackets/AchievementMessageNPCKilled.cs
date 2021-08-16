namespace Delphinus.InternalPackets
{
    internal class AchievementMessageNPCKilledPacket : IPacket
    {
        public MessageID Type => MessageID.AchievementMessageNPCKilled;
        public short NPCType { get; set; }
    }
}
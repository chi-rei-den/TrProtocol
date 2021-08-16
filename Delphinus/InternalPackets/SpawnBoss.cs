namespace Delphinus.InternalPackets
{
    internal class SpawnBossPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.SpawnBoss;
        public byte OtherPlayerSlot { get; set; }
        public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
        public short NPCType { get; set; }
    }
}
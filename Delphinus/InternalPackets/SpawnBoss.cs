namespace Delphinus.InternalPackets
{
    internal class SpawnBoss : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
        public short NPCType { get; set; }
    }
}
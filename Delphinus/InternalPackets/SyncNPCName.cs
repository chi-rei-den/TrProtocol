namespace Delphinus.InternalPackets
{
    internal class SyncNPCName : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        [S2COnly]
        public string NPCName { get; set; }
        [S2COnly]
        public int TownNpc { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class SyncNPCNamePacket : IPacket, INPCSlot
    {
        public MessageID Type => MessageID.SyncNPCName;
        public short NPCSlot { get; set; }
        [S2COnly]
        public string NPCName { get; set; }
        [S2COnly]
        public int TownNpc { get; set; }
    }
}
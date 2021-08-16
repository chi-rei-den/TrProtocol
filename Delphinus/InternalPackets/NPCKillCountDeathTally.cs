namespace Delphinus.InternalPackets
{
    internal class NPCKillCountDeathTallyPacket : IPacket
    {
        public MessageID Type => MessageID.NPCKillCountDeathTally;
        public short NPCType { get; set; }
        public int Count { get; set; }
    }
}
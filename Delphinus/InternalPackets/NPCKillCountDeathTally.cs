namespace Delphinus.InternalPackets
{
    internal class NPCKillCountDeathTally : IPacket
    {
        public short NPCType { get; set; }
        public int Count { get; set; }
    }
}
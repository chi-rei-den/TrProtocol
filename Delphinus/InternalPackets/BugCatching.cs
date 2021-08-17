namespace Delphinus.InternalPackets
{
    internal class BugCatching : IPacket, IPlayerSlot, INPCSlot
    {
        public short NPCSlot { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
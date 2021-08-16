namespace Delphinus.InternalPackets
{
    internal class BugCatchingPacket : IPacket, IPlayerSlot, INPCSlot
    {
        public MessageID Type => MessageID.BugCatching;
        public short NPCSlot { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
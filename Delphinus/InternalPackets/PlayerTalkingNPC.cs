namespace Delphinus.InternalPackets
{
    internal class PlayerTalkingNPCPacket : IPacket, IPlayerSlot, INPCSlot
    {
        public MessageID Type => MessageID.PlayerTalkingNPC;
        public byte PlayerSlot { get; set; }
        public short NPCSlot { get; set; }
    }
}
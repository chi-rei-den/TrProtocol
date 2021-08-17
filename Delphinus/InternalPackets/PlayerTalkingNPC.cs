namespace Delphinus.InternalPackets
{
    internal class PlayerTalkingNPC : IPacket, IPlayerSlot, INPCSlot
    {
        public byte PlayerSlot { get; set; }
        public short NPCSlot { get; set; }
    }
}
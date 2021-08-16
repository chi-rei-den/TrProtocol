namespace Delphinus.InternalPackets
{
    internal class StrikeNPCPacket : IPacket, INPCSlot
    {
        public MessageID Type => MessageID.StrikeNPC;
        public short NPCSlot { get; set; }
        public short Damage { get; set; }
        public float Knockback { get; set; }
        public byte HitDirection { get; set; }
        public bool Crit { get; set; }
    }
}
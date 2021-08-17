namespace Delphinus.InternalPackets
{
    internal class StrikeNPC : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public short Damage { get; set; }
        public float Knockback { get; set; }
        public byte HitDirection { get; set; }
        public bool Crit { get; set; }
    }
}
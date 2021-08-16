namespace Delphinus.InternalPackets
{
    internal class WiredCannonShotPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.WiredCannonShot;
        public short Damage { get; set; }
        public float Knockback { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short Angle { get; set; }
        public short Ammo { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    [Manual]
    internal class SyncProjectilePacket : IPacket, IProjSlot, IPlayerSlot
    {
        public MessageID Type => MessageID.SyncProjectile;
        public short ProjSlot { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public byte PlayerSlot { get; set; }
        public short ProjType { get; set; }
        public BitsByte Flags { get; set; }

        public float AI1 { get; set; }
        public float AI2 { get; set; }
        public ushort BannerId { get; set; }
        public short Damange { get; set; }
        public float Knockback { get; set; }
        public ushort OriginalDamage { get; set; }
        public short UUID { get; set; }

    }
}
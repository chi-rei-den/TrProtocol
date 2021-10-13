using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SyncProjectile : IPacket, IProjSlot, IPlayerSlot
    {
        public short ProjSlot { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public byte PlayerSlot { get; set; }
        public short ProjType { get; set; }

        public BitsByte Flags { get; set; }

        [Condition("{{packet}}.Flags[0]")] public float AI1 { get; set; }
        [Condition("{{packet}}.Flags[1]")] public float AI2 { get; set; }
        [Condition("{{packet}}.Flags[3]")] public ushort BannerId { get; set; }
        [Condition("{{packet}}.Flags[4]")] public short Damange { get; set; }
        [Condition("{{packet}}.Flags[5]")] public float Knockback { get; set; }
        [Condition("{{packet}}.Flags[6]")] public ushort OriginalDamage { get; set; }
        [Condition("{{packet}}.Flags[7]")] public short UUID { get; set; }
    }
}
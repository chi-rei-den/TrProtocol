using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class ItemTweaker : IPacket, IItemSlot
    {

        public short ItemSlot { get; set; }

        public BitsByte Flags1 { get; set; }
        [Condition("{{packet}}.Flags1[0]")] public uint PackedColor { get; set; }
        [Condition("{{packet}}.Flags1[1]")] public ushort Damage { get; set; }
        [Condition("{{packet}}.Flags1[2]")] public float Knockback { get; set; }
        [Condition("{{packet}}.Flags1[3]")] public ushort UseAnimation { get; set; }
        [Condition("{{packet}}.Flags1[4]")] public ushort UseTime { get; set; }
        [Condition("{{packet}}.Flags1[5]")] public short Shoot { get; set; }
        [Condition("{{packet}}.Flags1[6]")] public float ShootSpeed { get; set; }
        [Condition("{{packet}}.Flags1[7]")] public BitsByte Flags2 { get; set; }

        [Condition("{{packet}}.Flags2[0]")] public short Width { get; set; }
        [Condition("{{packet}}.Flags2[1]")] public short Height { get; set; }
        [Condition("{{packet}}.Flags2[2]")] public float Scale { get; set; }
        [Condition("{{packet}}.Flags2[3]")] public short Ammo { get; set; }
        [Condition("{{packet}}.Flags2[4]")] public short UseAmmo { get; set; }
        [Condition("{{packet}}.Flags2[5]")] public bool NotAmmo { get; set; }
    }
}
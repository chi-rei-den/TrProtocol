using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class ItemTweakerPacket : IPacket, IItemSlot
    {
        public MessageID Type => MessageID.ItemTweaker;

        public short ItemSlot { get; set; }

        public BitsByte Flags1 { get; set; }
        [Condition("{0}.Flags1[0]")] public uint PackedColor { get; set; }
        [Condition("{0}.Flags1[1]")] public ushort Damage { get; set; }
        [Condition("{0}.Flags1[2]")] public float Knockback { get; set; }
        [Condition("{0}.Flags1[3]")] public ushort UseAnimation { get; set; }
        [Condition("{0}.Flags1[4]")] public ushort UseTime { get; set; }
        [Condition("{0}.Flags1[5]")] public short Shoot { get; set; }
        [Condition("{0}.Flags1[6]")] public float ShootSpeed { get; set; }
        [Condition("{0}.Flags1[7]")] public BitsByte Flags2 { get; set; }

        [Condition("{0}.Flags2[0]")] public short Width { get; set; }
        [Condition("{0}.Flags2[1]")] public short Height { get; set; }
        [Condition("{0}.Flags2[2]")] public float Scale { get; set; }
        [Condition("{0}.Flags2[3]")] public short Ammo { get; set; }
        [Condition("{0}.Flags2[4]")] public short UseAmmo { get; set; }
        [Condition("{0}.Flags2[5]")] public bool NotAmmo { get; set; }
    }
}
using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayerHurtV2 : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public PlayerDeathReason Reason { get; set; }
        public short Damage { get; set; }
        public byte HitDirection { get; set; }
        public BitsByte Bits1 { get; set; }
        public sbyte CooldownCounter { get; set; }
    }
}
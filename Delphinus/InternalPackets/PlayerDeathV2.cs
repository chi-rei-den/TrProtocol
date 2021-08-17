using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayerDeathV2 : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public PlayerDeathReason Reason { get; set; }
        public short Damage { get; set; }
        public byte HitDirection { get; set; }
        public BitsByte Bits1 { get; set; }
    }
}
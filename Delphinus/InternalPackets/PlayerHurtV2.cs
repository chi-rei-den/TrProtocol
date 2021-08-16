using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayerHurtV2Packet : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.PlayerHurtV2;
        public byte OtherPlayerSlot { get; set; }
        public PlayerDeathReason Reason { get; set; }
        public short Damage { get; set; }
        public byte HitDirection { get; set; }
        public BitsByte Bits1 { get; set; }
    }
}
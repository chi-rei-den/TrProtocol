using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TeleportPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.Teleport;
        public BitsByte Bit1 { get; set; }
        public byte PlayerSlot { get; set; }
        public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
        public Vector2 Position { get; set; }
        public byte Style { get; set; }
        [Condition("Bit1", 3)] public int ExtraInfo { get; set; }
    }
}
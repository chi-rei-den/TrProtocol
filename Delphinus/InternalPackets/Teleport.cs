using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class Teleport : IPacket, IPlayerSlot
    {
        public BitsByte Flags { get; set; }

        public byte PlayerSlot { get; set; }

        public byte HighBitOfPlayerIsAlwaysZero { get; set; }

        public Vector2 Position { get; set; }

        public byte Style { get; set; }

        [Condition("{{packet}}.Flags[3]")] public int ExtraInfo { get; set; }
    }
}
using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TeleportPlayerThroughPortal : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public ushort Extra { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
    }
}
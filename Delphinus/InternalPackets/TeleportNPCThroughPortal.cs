using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TeleportNPCThroughPortal : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public ushort Extra { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
    }
}
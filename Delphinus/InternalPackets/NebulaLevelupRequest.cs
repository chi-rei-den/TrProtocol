using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class NebulaLevelupRequest : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public ushort NebulaType { get; set; }
        public Vector2 Position { get; set; }
    }
}
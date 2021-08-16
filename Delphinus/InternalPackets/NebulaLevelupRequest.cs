using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class NebulaLevelupRequestPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.NebulaLevelupRequest;
        public byte PlayerSlot { get; set; }
        public ushort NebulaType { get; set; }
        public Vector2 Position { get; set; }
    }
}
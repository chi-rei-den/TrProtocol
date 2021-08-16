using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class MinionRestTargetUpdatePacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.MinionRestTargetUpdate;
        public byte PlayerSlot { get; set; }
        public Vector2 MinionRestTargetPoint { get; set; }
    }
}
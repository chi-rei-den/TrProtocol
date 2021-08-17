using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class MinionRestTargetUpdate : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public Vector2 MinionRestTargetPoint { get; set; }
    }
}
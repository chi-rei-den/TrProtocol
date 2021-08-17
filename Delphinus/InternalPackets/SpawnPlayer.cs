using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SpawnPlayer : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public int Timer { get; set; }
        public PlayerSpawnContext Context { get; set; }
    }
}

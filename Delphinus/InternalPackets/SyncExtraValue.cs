using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SyncExtraValue : IPacket
    {
        public short NPCSlot { get; set; }
        public int Extra { get; set; }
        public Vector2 MoneyPing { get; set; }
    }
}
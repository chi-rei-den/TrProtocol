using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SyncRevengeMarker : IPacket
    {
        public int ID { get; set; }
        public Vector2 Position { get; set; }
        public int NetID { get; set; }
        public float Percent { get; set; }
        public int NPCType { get; set; }
        public int NPCAI { get; set; }
        public int CoinValue { get; set; }
        public float BaseValue { get; set; }
        public bool SpawnFromStatue { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class SyncPlayerChestIndex : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short ChestIndex { get; set; }
    }
}
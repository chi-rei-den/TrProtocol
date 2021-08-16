namespace Delphinus.InternalPackets
{
    internal class SyncPlayerChestIndexPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.SyncPlayerChestIndex;
        public byte PlayerSlot { get; set; }
        public short ChestIndex { get; set; }
    }
}
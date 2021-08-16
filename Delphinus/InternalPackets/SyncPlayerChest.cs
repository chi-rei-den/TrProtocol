namespace Delphinus.InternalPackets
{
    internal class SyncPlayerChestPacket : IPacket
    {
        public MessageID Type => MessageID.SyncPlayerChest;
        public short Chest { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte[] Extra { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class TileEntitySharingPacket : IPacket
    {
        public MessageID Type => MessageID.TileEntitySharing;
        public int ID { get; set; }
        public bool IsNew { get; set; }
        [Condition("IsNew")] public byte[] TileEntityData { get; set; }
    }
}
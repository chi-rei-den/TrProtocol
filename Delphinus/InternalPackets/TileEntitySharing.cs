namespace Delphinus.InternalPackets
{
    internal class TileEntitySharingPacket : IPacket
    {
        public MessageID Type => MessageID.TileEntitySharing;
        public int ID { get; set; }
        public bool IsNew { get; set; }
        //TODO
        // [Condition("{{packet}}.IsNew")] public byte[] TileEntityData { get; set; }
    }
}
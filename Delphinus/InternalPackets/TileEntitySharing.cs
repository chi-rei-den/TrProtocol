using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TileEntitySharingPacket : IPacket
    {
        public MessageID Type => MessageID.TileEntitySharing;
        public int ID { get; set; }
        public bool HasTileEntity { get; set; }
        [Condition("{{packet}}.HasTileEntity")]
        public TileEntity TileEntityData { get; set; }
    }
}
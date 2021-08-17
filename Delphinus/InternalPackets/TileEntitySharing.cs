using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TileEntitySharing : IPacket
    {
        public int ID { get; set; }
        public bool HasTileEntity { get; set; }
        [Condition("{{packet}}.HasTileEntity")]
        public TileEntity TileEntityData { get; set; }
    }
}
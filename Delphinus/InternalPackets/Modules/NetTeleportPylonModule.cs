using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetTeleportPylonModule : IPacket
    {
        public SubPacketType Type { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public TeleportPylonType PylonType { get; set; }
    }
}
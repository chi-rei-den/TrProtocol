using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetTeleportPylonModule : IPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetTeleportPylonModule;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public TeleportPylonType PylonType { get; set; }
    }
}
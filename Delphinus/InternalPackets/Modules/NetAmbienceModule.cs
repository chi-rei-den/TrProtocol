using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetAmbienceModule : NetModulesPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetAmbienceModule;
        public byte PlayerSlot { get; set; }
        public int Random { get; set; }
        public SkyEntityType SkyType { get; set; }
    }
}
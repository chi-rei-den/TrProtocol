using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativePowersModule : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetCreativePowersModule;
        public CreativePowerTypes PowerType { get; set; }
        public byte[] Extra { get; set; }
    }
}
using System;

namespace Delphinus.InternalPackets.Modules
{
    [C2SOnly]
    internal class NetTextModuleC2S : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetTextModule;
        public string Command { get; set; }
        public string Text { get; set; }
    }
}

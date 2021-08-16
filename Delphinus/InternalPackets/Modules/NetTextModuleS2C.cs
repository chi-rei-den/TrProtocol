using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    [S2COnly]
    internal class NetTextModuleS2C : NetModulesPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetTextModule;
        public byte PlayerSlot { get; set; }
        public NetworkText Text { get; set; }
        public Color Color { get; set; }
    }
}
using TrProtocol.Models;

namespace TrProtocol.Packets.Modules
{
    public class NetCreativeUnlocksModule : NetModulesPacket
    {
        public override MessageID Type => MessageID.NetModules;
        public override NetModuleType ModuleType => NetModuleType.NetCreativeUnlocksModule;

        [BoundWith("MaxItemType")]
        public short ItemId { get; set; }
        public ushort Count { get; set; }
    }
}
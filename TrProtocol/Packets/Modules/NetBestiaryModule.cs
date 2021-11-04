using TrProtocol.Models;

namespace TrProtocol.Packets.Modules
{
    public class NetBestiaryModule : NetModulesPacket
    {
        public override MessageID Type => MessageID.NetModules;
        public override NetModuleType ModuleType => NetModuleType.NetBestiaryModule;
        public byte UnlockType { get; set; }
        [BoundWith("MaxNPCID")]
        public short NPCNetID { get; set; }
        public byte[] Extra { get; set; }
    }
}
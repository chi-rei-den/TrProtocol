using TrProtocol.Models;

namespace TrProtocol.Packets.Modules
{
    public class NetBestiaryModule : NetModulesPacket
    {
        public override MessageID Type => MessageID.NetModules;
        public override NetModuleType ModuleType => NetModuleType.NetBestiaryModule;
        public BestiaryUnlockType UnlockType { get; set; }
        [BoundWith("MaxNPCID")]
        public short NPCNetID { get; set; }
        private bool _killCount => UnlockType == BestiaryUnlockType.Kill;
        [Condition("_killCount")]
        public ushort KillCount { get; set; }
    }
}
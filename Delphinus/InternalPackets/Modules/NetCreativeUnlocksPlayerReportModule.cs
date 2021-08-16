namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativeUnlocksPlayerReportModule : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetCreativeUnlocksPlayerReportModule;
        public byte AlwaysZero { get; set; } = 0;
        public short ItemId { get; set; }
        public ushort Count { get; set; }
    }
}
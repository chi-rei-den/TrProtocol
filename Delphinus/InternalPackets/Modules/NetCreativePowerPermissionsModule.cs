namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativePowerPermissionsModule : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetCreativePowerPermissionsModule;
        public byte AlwaysZero { get; set; } = 0;
        public ushort PowerId { get; set; }
        public byte Level { get; set; }
    }
}
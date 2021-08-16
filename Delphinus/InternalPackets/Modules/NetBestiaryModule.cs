namespace Delphinus.InternalPackets.Modules
{
    internal class NetBestiaryModule : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetBestiaryModule;
        public byte[] Extra { get; set; }
    }
}
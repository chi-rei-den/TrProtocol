namespace Delphinus.InternalPackets.Modules
{
    internal class NetParticlesModule : NetModulesPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetParticlesModule;
    }
}
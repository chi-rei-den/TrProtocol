namespace Delphinus.InternalPackets.Modules
{
    internal class NetParticlesModule : IPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetParticlesModule;
    }
}
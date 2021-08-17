namespace Delphinus.InternalPackets.Modules
{
    internal class NetLiquidModule : IPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetLiquidModule;
        public ushort Count { get; set; }
        public byte[] Changes { get; set; }
    }
}
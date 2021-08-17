namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativeUnlocksModule : IPacket
    {
        public MessageID Type => MessageID.NetModules;
        public NetModuleType ModuleType => NetModuleType.NetCreativeUnlocksModule;
        public short ItemId { get; set; }
        public ushort Count { get; set; }
    }
}
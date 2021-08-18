namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativeUnlocksModule : IPacket
    {
        public short ItemId { get; set; }
        public ushort Count { get; set; }
    }
}
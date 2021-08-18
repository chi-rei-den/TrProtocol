namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativeUnlocksPlayerReportModule : IPacket
    {
        public byte AlwaysZero { get; set; } = 0;
        public short ItemId { get; set; }
        public ushort Count { get; set; }
    }
}
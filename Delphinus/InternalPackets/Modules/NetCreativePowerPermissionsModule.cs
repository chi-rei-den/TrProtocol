namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativePowerPermissionsModule : IPacket
    {
        public byte AlwaysZero { get; set; } = 0;
        public ushort PowerId { get; set; }
        public byte Level { get; set; }
    }
}
namespace Delphinus.InternalPackets.Modules
{
    internal class NetLiquidModule : IPacket
    {
        public ushort Count { get; set; }
        [Arguments("{{packet}}.Count")]
        public (ushort, ushort, byte, byte)[] Data { get; set; }
    }
}
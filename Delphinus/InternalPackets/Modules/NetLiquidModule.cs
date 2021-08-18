using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetLiquidModule : IPacket
    {
        public ushort Count { get; set; }
        [Arguments("{{packet}}.Count")]
        public NetLiquidData[] Data { get; set; }
    }
}
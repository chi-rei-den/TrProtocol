using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativePowersModule : IPacket
    {
        [Arguments("-1")]
        public byte[] PowerType { get; set; }
    }
}
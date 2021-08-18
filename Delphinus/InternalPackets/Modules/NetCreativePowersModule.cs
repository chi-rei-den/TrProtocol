using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetCreativePowersModule : IPacket
    {
        public ICreativePower PowerType { get; set; }
    }
}
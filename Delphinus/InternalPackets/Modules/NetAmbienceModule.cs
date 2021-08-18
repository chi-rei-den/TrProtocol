using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetAmbienceModule : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public int Random { get; set; }
        public SkyEntityType SkyType { get; set; }
    }
}
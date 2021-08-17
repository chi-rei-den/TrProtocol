using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class StatusText : IPacket
    {
        public int Max { get; set; }
        public NetworkText Text { get; set; }
        public byte Flag { get; set; }
    }
}

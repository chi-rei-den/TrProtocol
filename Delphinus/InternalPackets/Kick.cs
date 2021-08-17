using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class Kick : IPacket
    {
        public NetworkText Reason { get; set; }
    }
}

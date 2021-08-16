using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class KickPacket : IPacket
    {
        public MessageID Type => MessageID.Kick;
        public NetworkText Reason { get; set; }
    }
}

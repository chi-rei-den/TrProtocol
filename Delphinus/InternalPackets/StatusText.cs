using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class StatusTextPacket : IPacket
    {
        public MessageID Type => MessageID.StatusText;
        public int Max { get; set; }
        public NetworkText Text { get; set; }
        public byte Flag { get; set; }
    }
}

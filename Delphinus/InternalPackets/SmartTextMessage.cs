using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SmartTextMessagePacket : IPacket
    {
        public MessageID Type => MessageID.SmartTextMessage;
        public Color Color { get; set; }
        public NetworkText Text { get; set; }
        public short Width { get; set; }
    }
}

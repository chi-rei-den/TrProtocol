using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SmartTextMessage : IPacket
    {
        public Color Color { get; set; }
        public NetworkText Text { get; set; }
        public short Width { get; set; }
    }
}

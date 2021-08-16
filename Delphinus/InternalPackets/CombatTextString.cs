using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class CombatTextStringPacket : IPacket
    {
        public MessageID Type => MessageID.CombatTextString;
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public NetworkText Text { get; set; }
    }
}
using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class CombatTextString : IPacket
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public NetworkText Text { get; set; }
    }
}
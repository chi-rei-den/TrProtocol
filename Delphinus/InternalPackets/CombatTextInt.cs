using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class CombatTextInt : IPacket
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public int Amount { get; set; }
    }
}
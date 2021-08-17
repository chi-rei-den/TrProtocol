using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayLegacySound : IPacket
    {
        public Vector2 Point { get; set; }
        public ushort Sound { get; set; }
        public BitsByte Flags { get; set; }
        [Condition("{{packet}}.Flags[0]")]
        public int Style { get; set; }
        [Condition("{{packet}}.Flags[1]")]
        [Expression("MathHelper.Clamp(value, 0, 1f)", Usage.Deserialize)]
        public float Volume { get; set; }
        [Condition("{{packet}}.Flags[2]")]
        [Expression("MathHelper.Clamp(value, -1f, 1f)", Usage.Deserialize)]
        public float Pitch { get; set; }
    }
}
using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayLegacySoundPacket : IPacket
    {
        public MessageID Type => MessageID.PlayLegacySound;
        public Vector2 Point { get; set; }
        public ushort Sound { get; set; }
        public BitsByte Flags { get; set; }
        [Condition("{0}.Flags[0]")]
        public int Style { get; set; }
        [Condition("{0}.Flags[1]")]
        [Expression("MathHelper.Clamp({0}, 0, 1f)", Usage.Deserialization)]
        public float Volume { get; set; }
        [Condition("{0}.Flags[2]")]
        [Expression("MathHelper.Clamp({0}, -1f, 1f)", Usage.Deserialization)]
        public float Pitch { get; set; }
    }
}
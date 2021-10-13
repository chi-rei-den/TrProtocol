using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SyncPlayer : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public byte SkinVariant { get; set; }
        public byte Hair { get; set; }
        public string Name { get; set; }
        public byte HairDye { get; set; }
        public BitsByte HideVisuals1 { get; set; }
        public BitsByte HideVisuals2 { get; set; }
        public BitsByte HideMisc { get; set; }
        public Color HairColor { get; set; }
        public Color SkinColor { get; set; }
        public Color EyeColor { get; set; }
        public Color ShirtColor { get; set; }
        public Color UnderShirtColor { get; set; }
        public Color PantsColor { get; set; }
        public Color ShoeColor { get; set; }
        public BitsByte Difficulty { get; set; }
        public BitsByte Torch { get; set; }
    }
}

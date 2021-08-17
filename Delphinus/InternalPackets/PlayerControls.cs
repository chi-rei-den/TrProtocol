using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayerControls : IPacket, IPlayerSlot
    {

        public byte PlayerSlot { get; set; }

        public BitsByte ControlFlags { get; set; }
        public BitsByte PulleyFlags { get; set; }
        public BitsByte MiscFlags { get; set; }
        public BitsByte SleepFlags { get; set; }

        public byte SelectedItem { get; set; }
        public Vector2 Position { get; set; }

        [Condition("{{packet}}.PulleyFlags[2]")]
        public Vector2 Velocity { get; set; }
        [Condition("{{packet}}.MiscFlags[6]")]
        public Vector2 PotionOfReturnOriginalUsePosition { get; set; }
        [Condition("{{packet}}.MiscFlags[6]")]
        public Vector2 PotionOfReturnHomePosition { get; set; }
    }
}

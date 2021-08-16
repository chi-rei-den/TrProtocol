using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class PlayerControlsPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerControls;

        public byte PlayerSlot { get; set; }

        public BitsByte ControlFlags { get; set; }
        public BitsByte PulleyFlags { get; set; }
        public BitsByte MiscFlags { get; set; }
        public BitsByte SleepFlags { get; set; }

        public byte SelectedItem { get; set; }
        public Vector2 Position { get; set; }
        [Condition("{0}.PulleyFlags[2]", Usage.Serialization)]
        public Vector2 Velocity { get; set; }
        [Condition("{0}.MiscFlags[6]", Usage.Serialization)]
        public Vector2 PotionOfReturnOriginalUsePosition { get; set; }
        [Condition("{0}.MiscFlags[6]", Usage.Serialization)]
        public Vector2 PotionOfReturnHomePosition { get; set; }
    }
}

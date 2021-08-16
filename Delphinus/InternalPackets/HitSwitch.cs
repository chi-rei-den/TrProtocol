namespace Delphinus.InternalPackets
{
    internal class HitSwitchPacket : IPacket
    {
        public MessageID Type => MessageID.HitSwitch;
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
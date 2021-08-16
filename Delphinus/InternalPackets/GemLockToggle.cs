namespace Delphinus.InternalPackets
{
    internal class GemLockTogglePacket : IPacket
    {
        public MessageID Type => MessageID.GemLockToggle;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public bool Flag { get; set; }
    }
}
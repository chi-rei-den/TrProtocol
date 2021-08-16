namespace Delphinus.InternalPackets
{
    internal class UnlockPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.Unlock;
        public byte PlayerSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
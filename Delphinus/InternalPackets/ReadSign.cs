namespace Delphinus.InternalPackets
{
    internal class ReadSignPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.ReadSign;
        public short SignSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte PlayerSlot { get; set; }
        public byte Bit1 { get; set; }
    }
}
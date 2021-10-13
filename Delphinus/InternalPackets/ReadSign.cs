namespace Delphinus.InternalPackets
{
    internal class ReadSign : IPacket, IPlayerSlot
    {
        public short SignSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public string Text { get; set; }
        public byte PlayerSlot { get; set; }
        public byte Bit1 { get; set; }
    }
}
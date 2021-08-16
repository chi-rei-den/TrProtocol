namespace Delphinus.InternalPackets
{
    internal class ChestNamePacket : IPacket
    {
        public MessageID Type => MessageID.ChestName;
        public short ChestSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public string Name { get; set; }
    }
}
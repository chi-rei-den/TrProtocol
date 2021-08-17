namespace Delphinus.InternalPackets
{
    internal class ChestName : IPacket
    {
        public short ChestSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public string Name { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class SpecialFXPacket : IPacket
    {
        public MessageID Type => MessageID.SpecialFX;
        public byte GrowType { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public byte Height { get; set; }
        public short Gore { get; set; }
    }
}
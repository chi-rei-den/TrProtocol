namespace Delphinus.InternalPackets
{
    internal class PlaceObjectPacket : IPacket
    {
        public MessageID Type => MessageID.PlaceObject;
        public short PosX { get; set; }
        public short PosY { get; set; }
        public short ObjectType { get; set; }
        public short Style { get; set; }
        public byte Alternate { get; set; }
        public sbyte Random { get; set; }
        public bool Direction { get; set; }
    }
}
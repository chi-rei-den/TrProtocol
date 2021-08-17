namespace Delphinus.InternalPackets
{
    internal class Dodge : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public byte DodgeType { get; set; }
    }
}
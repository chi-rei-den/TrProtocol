namespace Delphinus.InternalPackets
{
    internal class Assorted1 : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public byte Unknown { get; set; }
    }
}
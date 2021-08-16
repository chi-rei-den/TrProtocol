namespace Delphinus.InternalPackets
{
    internal class Assorted1Packet : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.Assorted1;
        public byte PlayerSlot { get; set; }
        public byte Unknown { get; set; }
    }
}
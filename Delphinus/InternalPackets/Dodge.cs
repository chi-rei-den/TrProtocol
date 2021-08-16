namespace Delphinus.InternalPackets
{
    internal class DodgePacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.Dodge;
        public byte PlayerSlot { get; set; }
        public byte DodgeType { get; set; }
    }
}
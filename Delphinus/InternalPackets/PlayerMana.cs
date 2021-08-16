namespace Delphinus.InternalPackets
{
    internal class PlayerManaPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerMana;
        public byte PlayerSlot { get; set; }
        public short StatMana { get; set; }
        public short StatManaMax { get; set; }
    }
}
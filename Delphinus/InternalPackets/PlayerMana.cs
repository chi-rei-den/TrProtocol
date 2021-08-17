namespace Delphinus.InternalPackets
{
    internal class PlayerMana : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short StatMana { get; set; }
        public short StatManaMax { get; set; }
    }
}
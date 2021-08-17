namespace Delphinus.InternalPackets
{
    internal class PlayerActive : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public bool Active { get; set; }
    }
}

namespace Delphinus.InternalPackets
{
    internal class ManaEffect : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short Amount { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class PlayerZone : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public int Zone { get; set; }
    }
}
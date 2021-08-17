namespace Delphinus.InternalPackets
{
    internal class PlayNote : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public float Range { get; set; }
    }
}
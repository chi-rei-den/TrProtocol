namespace Delphinus.InternalPackets
{
    internal class LoadPlayer : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
    }
}

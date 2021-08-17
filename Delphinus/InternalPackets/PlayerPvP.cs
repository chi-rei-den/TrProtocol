namespace Delphinus.InternalPackets
{
    internal class PlayerPvP : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public bool Pvp { get; set; }
    }
}
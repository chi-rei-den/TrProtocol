namespace Delphinus.InternalPackets
{
    internal class PlayerHealth : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short StatLife { get; set; }
        public short StatLifeMax { get; set; }
    }
}

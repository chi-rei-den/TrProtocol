namespace Delphinus.InternalPackets
{
    internal class PlayerBuffs : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        [Arguments("22")]
        public ushort[] BuffTypes { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class PlayerTeam : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public byte Team { get; set; }
    }
}
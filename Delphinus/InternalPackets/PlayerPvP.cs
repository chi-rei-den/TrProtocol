namespace Delphinus.InternalPackets
{
    internal class PlayerPvPPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerPvP;
        public byte PlayerSlot { get; set; }
        public bool Pvp { get; set; }
    }
}
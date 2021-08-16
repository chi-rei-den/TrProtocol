namespace Delphinus.InternalPackets
{
    internal class PlayerTeamPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerTeam;
        public byte PlayerSlot { get; set; }
        public byte Team { get; set; }
    }
}
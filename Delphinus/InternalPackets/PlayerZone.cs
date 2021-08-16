namespace Delphinus.InternalPackets
{
    internal class PlayerZonePacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerZone;
        public byte PlayerSlot { get; set; }
        public int Zone { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class MoonlordCountdownPacket : IPacket
    {
        public MessageID Type => MessageID.MoonlordCountdown;
        public int Countdown { get; set; }
    }
}
using TrProtocol.Models;

namespace TrProtocol.Packets
{
    public class RequestLucyPopup : Packet
    {
        public override MessageID Type => MessageID.RequestLucyPopup;
        public MessageSource Source { get; set; }
        public byte Variation { get; set; }
        public Vector2 Velocity { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}

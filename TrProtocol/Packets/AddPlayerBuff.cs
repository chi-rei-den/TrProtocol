namespace TrProtocol.Packets
{
    public class AddPlayerBuff : Packet, IOtherPlayerSlot
    {
        public override MessageID Type => MessageID.AddPlayerBuff;
        public byte OtherPlayerSlot { get; set; }
        [BoundWith("MaxBuffType")]
        public ushort BuffType { get; set; }
        public int BuffTime { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class AddPlayerBuffPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.AddPlayerBuff;
        public byte OtherPlayerSlot { get; set; }
        public ushort BuffType { get; set; }
        public int BuffTime { get; set; }
    }
}
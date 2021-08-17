namespace Delphinus.InternalPackets
{
    internal class AddPlayerBuff : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public ushort BuffType { get; set; }
        public int BuffTime { get; set; }
    }
}
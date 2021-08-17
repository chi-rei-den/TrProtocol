namespace Delphinus.InternalPackets
{
    internal class SetCountsAsHostForGameplay : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public bool Flag { get; set; }
    }
}
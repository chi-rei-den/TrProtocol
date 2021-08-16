namespace Delphinus.InternalPackets
{
    internal class SetCountsAsHostForGameplayPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.SetCountsAsHostForGameplay;
        public byte OtherPlayerSlot { get; set; }
        public bool Flag { get; set; }
    }
}
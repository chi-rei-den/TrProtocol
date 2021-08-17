namespace Delphinus.InternalPackets
{
    internal class DeadPlayer : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class DeadPlayerPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.DeadPlayer;
        public byte OtherPlayerSlot { get; set; }
    }
}
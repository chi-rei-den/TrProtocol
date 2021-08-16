namespace Delphinus.InternalPackets
{
    internal class LoadPlayerPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.LoadPlayer;
        public byte PlayerSlot { get; set; }
    }
}

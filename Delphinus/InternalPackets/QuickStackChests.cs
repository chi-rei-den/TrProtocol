namespace Delphinus.InternalPackets
{
    internal class QuickStackChestsPacket : IPacket
    {
        public MessageID Type => MessageID.QuickStackChests;
        public byte ChestSlot { get; set; }
    }
}
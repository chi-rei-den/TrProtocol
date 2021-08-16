namespace Delphinus.InternalPackets
{
    internal class TeleportationPotionPacket : IPacket
    {
        public MessageID Type => MessageID.TeleportationPotion;
        public byte Style { get; set; }
    }
}
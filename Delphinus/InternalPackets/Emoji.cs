namespace Delphinus.InternalPackets
{
    internal class EmojiPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.Emoji;
        public byte PlayerSlot { get; set; }
        public byte Emote { get; set; }
    }
}
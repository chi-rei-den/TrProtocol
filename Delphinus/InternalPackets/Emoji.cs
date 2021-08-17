namespace Delphinus.InternalPackets
{
    internal class Emoji : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public byte Emote { get; set; }
    }
}
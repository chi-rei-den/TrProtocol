namespace Delphinus.InternalPackets
{
    internal class PlayNotePacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayNote;
        public byte PlayerSlot { get; set; }
        public float Range { get; set; }
    }
}
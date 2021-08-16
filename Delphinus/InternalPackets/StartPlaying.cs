namespace Delphinus.InternalPackets
{
    internal class StartPlayingPacket : IPacket
    {
        public MessageID Type => MessageID.StartPlaying;
    }
}

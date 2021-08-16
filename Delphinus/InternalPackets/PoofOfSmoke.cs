namespace Delphinus.InternalPackets
{
    internal class PoofOfSmokePacket : IPacket
    {
        public MessageID Type => MessageID.PoofOfSmoke;
        public uint PackedHalfVector2 { get; set; }
    }
}
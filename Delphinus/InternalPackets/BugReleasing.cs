namespace Delphinus.InternalPackets
{
    internal class BugReleasingPacket : IPacket
    {
        public MessageID Type => MessageID.BugReleasing;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public short NPCType { get; set; }
        public byte Style { get; set; }
    }
}
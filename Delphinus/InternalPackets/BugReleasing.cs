namespace Delphinus.InternalPackets
{
    internal class BugReleasing : IPacket
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public short NPCType { get; set; }
        public byte Style { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class TileCounts : IPacket
    {
        public byte Good { get; set; }
        public byte Evil { get; set; }
        public byte Blood { get; set; }
    }
}
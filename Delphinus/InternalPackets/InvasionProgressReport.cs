namespace Delphinus.InternalPackets
{
    internal class InvasionProgressReport : IPacket
    {
        public int Progress { get; set; }
        public int ProgressMax { get; set; }
        public sbyte Icon { get; set; }
        public sbyte Wave { get; set; }
    }
}
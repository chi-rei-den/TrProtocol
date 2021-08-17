namespace Delphinus.InternalPackets
{
    internal class MenuSunMoon : IPacket
    {
        public bool DayTime { get; set; }
        public int Time { get; set; }
        public short Sun { get; set; }
        public short Moon { get; set; }
    }
}

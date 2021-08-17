namespace Delphinus.InternalPackets
{
    internal class UpdateTowerShieldStrengths : IPacket
    {
        public ushort SolarShieldStrength { get; set; }
        public ushort VortexShieldStrength { get; set; }
        public ushort NebulaShieldStrength { get; set; }
        public ushort StardustShieldStrength { get; set; }
    }
}
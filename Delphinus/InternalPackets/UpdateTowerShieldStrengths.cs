namespace Delphinus.InternalPackets
{
    internal class UpdateTowerShieldStrengthsPacket : IPacket
    {
        public MessageID Type => MessageID.UpdateTowerShieldStrengths;
        [Arguments("4")]
        public ushort[] ShieldStrength { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class UpdateTowerShieldStrengthsPacket : IPacket
    {
        public MessageID Type => MessageID.UpdateTowerShieldStrengths;
        [ArraySize(4)] public ushort[] ShieldStrength { get; set; }
    }
}
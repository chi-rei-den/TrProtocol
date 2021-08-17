namespace Delphinus.InternalPackets
{
    internal class PlayerBuffsPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.PlayerBuffs;
        public byte PlayerSlot { get; set; }
        [Arguments("22")]
        public ushort[] BuffTypes { get; set; }
    }
}
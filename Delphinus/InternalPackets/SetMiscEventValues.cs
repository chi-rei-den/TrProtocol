namespace Delphinus.InternalPackets
{
    internal class SetMiscEventValues : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public int CreditsRollTime { get; set; }
    }
}
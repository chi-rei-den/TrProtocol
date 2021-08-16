namespace Delphinus.InternalPackets
{
    internal class SetMiscEventValuesPacket : IPacket, IOtherPlayerSlot
    {
        public MessageID Type => MessageID.SetMiscEventValues;
        public byte OtherPlayerSlot { get; set; }
        public int CreditsRollTime { get; set; }
    }
}
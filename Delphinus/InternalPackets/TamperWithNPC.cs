namespace Delphinus.InternalPackets
{
    internal class TamperWithNPC : IPacket, INPCSlot, IOtherPlayerSlot
    {
        public short NPCSlot { get; set; }

        public byte UniqueImmune { get; set; }

        [Condition("{{packet}}.UniqueImmune == 1")] public int Time { get; set; }
        [Condition("{{packet}}.UniqueImmune == 1")] public byte OtherPlayerSlot { get; set; }
        public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
    }
}
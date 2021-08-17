namespace Delphinus.InternalPackets
{
    internal class SendNPCBuffs : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public ushort BuffType1 { get; set; }
        public short BuffTime1 { get; set; }
        public ushort BuffType2 { get; set; }
        public short BuffTime2 { get; set; }
        public ushort BuffType3 { get; set; }
        public short BuffTime3 { get; set; }
        public ushort BuffType4 { get; set; }
        public short BuffTime4{ get; set; }
        public ushort BuffType5 { get; set; }
        public short BuffTime5 { get; set; }
    }
}
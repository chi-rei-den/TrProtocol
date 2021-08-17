namespace Delphinus.InternalPackets
{
    internal class NPCHome : IPacket, INPCSlot
    {
        public short NPCSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
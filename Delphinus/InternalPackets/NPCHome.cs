namespace Delphinus.InternalPackets
{
    internal class NPCHomePacket : IPacket, INPCSlot
    {
        public MessageID Type => MessageID.NPCHome;
        public short NPCSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
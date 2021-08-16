namespace Delphinus.InternalPackets
{
    internal class FishOutNPCPacket : IPacket
    {
        public MessageID Type => MessageID.FishOutNPC;
        public ushort PosX { get; set; }
        public ushort PosY { get; set; }
        public short Start { get; set; }
    }
}
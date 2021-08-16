namespace Delphinus.InternalPackets
{
    internal class MassWireOperationPayPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.MassWireOperationPay;
        public short ItemType { get; set; }
        public short Stack { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
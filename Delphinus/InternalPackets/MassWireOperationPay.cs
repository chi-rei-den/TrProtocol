namespace Delphinus.InternalPackets
{
    internal class MassWireOperationPay : IPacket, IPlayerSlot
    {
        public short ItemType { get; set; }
        public short Stack { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
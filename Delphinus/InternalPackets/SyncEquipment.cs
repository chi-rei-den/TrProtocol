namespace Delphinus.InternalPackets
{
    internal class SyncEquipmentPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.SyncEquipment;
        public byte PlayerSlot { get; set; }
        public short ItemSlot { get; set; }
        public short Stack { get; set; }
        public byte Prefix { get; set; }
        public short ItemType { get; set; }
    }
}

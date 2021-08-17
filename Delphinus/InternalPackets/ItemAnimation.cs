namespace Delphinus.InternalPackets
{
    internal class ItemAnimation : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public float Rotation { get; set; }
        public short Animation { get; set; }
    }
}
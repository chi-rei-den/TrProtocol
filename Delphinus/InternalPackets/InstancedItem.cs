using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class InstancedItemPacket : IPacket, IItemSlot
    {
        public MessageID Type => MessageID.InstancedItem;
        public short ItemSlot { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public short Stack { get; set; }
        public byte Prefix { get; set; }
        public byte Owner { get; set; }
        public short ItemType { get; set; }
    }
}

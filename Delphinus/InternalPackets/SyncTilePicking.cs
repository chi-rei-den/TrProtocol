namespace Delphinus.InternalPackets
{
    internal class SyncTilePickingPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.SyncTilePicking;
        public byte PlayerSlot { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        public byte Damage { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class TEDisplayDollItemSyncPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.TEDisplayDollItemSync;
        public byte PlayerSlot { get; set; }
        //FIXME: FUCKING TERRIBLE FORMAT
        public byte[] Extra { get; set; }
    }
}
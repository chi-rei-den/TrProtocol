namespace Delphinus.InternalPackets
{
    internal class TEHatRackItemSyncPacket : IPacket, IPlayerSlot
    {
        public MessageID Type => MessageID.TEHatRackItemSync;
        public byte PlayerSlot { get; set; }
        //FIXME: FUCKING TERRIBLE FORMAT
        public byte[] Extra { get; set; }
    }
}
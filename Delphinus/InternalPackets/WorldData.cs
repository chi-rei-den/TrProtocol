namespace Delphinus.InternalPackets
{
    internal class WorldDataPacket : IPacket
    {
        public MessageID Type => MessageID.WorldData;
        //TODO
        // public byte[] Data { get; set; }
    }
}

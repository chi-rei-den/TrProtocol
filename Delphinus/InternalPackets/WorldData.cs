namespace Delphinus.InternalPackets
{
    internal class WorldDataPacket : IPacket
    {
        public MessageID Type => MessageID.WorldData;
        public byte[] Data { get; set; }
    }
}

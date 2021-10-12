namespace Delphinus.InternalPackets
{
    internal class TileSection : IPacket
    {
        public bool IsCompressed { get; set; }
        //[Arguments("-1")] public byte[] Data { get; set; }
        [Arguments("{{packet}}.IsCompressed")] public SectionData Data { get; set; }
    }
}

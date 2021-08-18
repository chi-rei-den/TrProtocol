using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class TileSquare : IPacket
    {
        public short TilePosX { get; set; }
        public short TilePosY { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public TileChangeType Type { get; set; }
        [Arguments("{{packet}}.Width", "{{packet}}.Height")]
        public SimpleTileData[,] Tiles { get; set; }
    }
}

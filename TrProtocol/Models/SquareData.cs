using System;

namespace TrProtocol.Models
{
    [LegacySerializer]
    public partial class SquareData
    {
        [ProtocolVersion("TerrariaXD230")]
        [ProtocolVersion("Terraria230")]
        public ushort Size
        {
            get
            {
                if (Height != Width)
                    throw new ArgumentException("SquareData in 1405 only support square size tile data");
                return (ushort)(Height | (HasChangeType ? 0x8000u : 0));
            }
            set
            {
                Height = (byte)value;
                Width = (byte)value;
                HasChangeType = (value & 0x8000u) != 0;
            }
        }
        [ProtocolVersion("TerrariaXD230")]
        [ProtocolVersion("Terraria230")]
        [Condition("HasChangeType")]
        public TileChangeType ChangeTypeFor1405
        {
            get => ChangeType;
            set => ChangeType = value;
        }

        public short TilePosX { get; set; }
        public short TilePosY { get; set; }
        [ProtocolVersion("Terraria238")]
        public byte Width { get; set; }
        [ProtocolVersion("Terraria238")]
        public byte Height { get; set; }
        [ProtocolVersion("Terraria238")]
        public TileChangeType ChangeType { get; set; }
        [ArraySize("Width", "Height")]
        public SimpleTileData[,] Tiles { get; set; }
        private bool HasChangeType { get; set; }

    }
}

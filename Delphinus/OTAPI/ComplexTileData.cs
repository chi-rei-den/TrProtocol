using Terraria;

namespace Delphinus
{
    public struct ComplexTileData
    {
        public BitsByte Flags1;
        public BitsByte Flags2;
        public BitsByte Flags3;

        public ushort TileType { get; set; }
        public short FrameX { get; set; }
        public short FrameY { get; set; }
        public byte TileColor { get; set; }
        public ushort WallType { get; set; }
        public byte WallColor { get; set; }
        public byte Liquid { get; set; }

        public short Count { get; set; }

        #region Generated

        public bool Equals(ComplexTileData other)
        {
            return Flags1.Equals(other.Flags1) && Flags2.Equals(other.Flags2) && Flags3.Equals(other.Flags3) && TileType == other.TileType && FrameX == other.FrameX && FrameY == other.FrameY && TileColor == other.TileColor && WallType == other.WallType && WallColor == other.WallColor && Liquid == other.Liquid;
        }

        public override bool Equals(object obj)
        {
            return obj is ComplexTileData other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Flags1.GetHashCode();
                hashCode = (hashCode * 397) ^ Flags2.GetHashCode();
                hashCode = (hashCode * 397) ^ Flags3.GetHashCode();
                hashCode = (hashCode * 397) ^ TileType.GetHashCode();
                hashCode = (hashCode * 397) ^ FrameX.GetHashCode();
                hashCode = (hashCode * 397) ^ FrameY.GetHashCode();
                hashCode = (hashCode * 397) ^ TileColor.GetHashCode();
                hashCode = (hashCode * 397) ^ WallType.GetHashCode();
                hashCode = (hashCode * 397) ^ WallColor.GetHashCode();
                hashCode = (hashCode * 397) ^ Liquid.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
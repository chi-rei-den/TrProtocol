using System.IO;

namespace TrProtocol.Models
{
    [Serializer(typeof(SquareDataSerializer1405), "TerrariaXD230")]
    [Serializer(typeof(SquareDataSerializer1405), "Terraria230")]
    [Serializer(typeof(SquareDataSerializer1405), "Terraria233")]
    [Serializer(typeof(SquareDataSerializer1405), "Terraria234")]
    [Serializer(typeof(SquareDataSerializer))]
    public partial class SquareData
    {
        private class SquareDataSerializer : FieldSerializer<SquareData>
        {
            protected override SquareData _Read(BinaryReader br)
            {
                var square = new SquareData()
                {
                    TilePosX = br.ReadInt16(),
                    TilePosY = br.ReadInt16(),
                    Width = br.ReadByte(),
                    Height = br.ReadByte(),
                    ChangeType = (TileChangeType)br.ReadByte(),
                };
                square.Tiles = new SimpleTileData[square.Width, square.Height];
                for (int i = 0; i < square.Width; i++)
                {
                    for (int j = 0; j < square.Height; j++)
                    {
                        var tile = new SimpleTileData
                        {
                            Flags1 = br.ReadByte(),
                            Flags2 = br.ReadByte()
                        };
                        if (tile.Flags2[2])
                        {
                            tile.TileColor = br.ReadByte();
                        }
                        if (tile.Flags2[3])
                        {
                            tile.WallColor = br.ReadByte();
                        }
                        if (tile.Flags1[0])
                        {
                            tile.TileType = br.ReadUInt16();
                            if (Constants.tileFrameImportant[tile.TileType])
                            {
                                tile.FrameX = br.ReadInt16();
                                tile.FrameY = br.ReadInt16();
                            }
                        }
                        if (tile.Flags1[2])
                        {
                            tile.WallType = br.ReadUInt16();
                        }
                        if (tile.Flags1[3])
                        {
                            tile.Liquid = br.ReadByte();
                            tile.LiquidType = br.ReadByte();
                        }
                        square.Tiles[i, j] = tile;
                    }
                }
                return square;
            }
            protected override void _Write(BinaryWriter bw, SquareData t)
            {
                bw.Write(t.TilePosX);
                bw.Write(t.TilePosY);
                bw.Write(t.Width);
                bw.Write(t.Height);
                bw.Write((byte)t.ChangeType);
                for (int i = 0; i < t.Tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < t.Tiles.GetLength(1); j++)
                    {
                        var tile = t.Tiles[i, j];
                        var flags1 = tile.Flags1;
                        var flags2 = tile.Flags2;
                        bw.Write(flags1);
                        bw.Write(flags2);

                        if (flags2[2])
                        {
                            bw.Write(tile.TileColor);
                        }
                        if (flags2[3])
                        {
                            bw.Write(tile.WallColor);
                        }
                        if (flags1[0])
                        {
                            bw.Write(tile.TileType);
                            if (Constants.tileFrameImportant[tile.TileType])
                            {
                                bw.Write(tile.FrameX);
                                bw.Write(tile.FrameY);
                            }
                        }
                        if (flags1[2])
                        {
                            bw.Write(tile.WallType);
                        }
                        if (flags1[3])
                        {
                            bw.Write(tile.Liquid);
                            bw.Write(tile.LiquidType);
                        }
                    }
                }
            }
        }
        private class SquareDataSerializer1405 : FieldSerializer<SquareData>
        {
            protected override SquareData _Read(BinaryReader br)
            {
                var size = br.ReadUInt16();
                var squareData_ = new SquareData
                {
                    Height = (byte)size,
                    Width = (byte)size
                };
                if ((size & 0x8000u) != 0)
                {
                    squareData_.ChangeType = (TileChangeType)br.ReadByte();
                }
                squareData_.TilePosX = br.ReadInt16();
                squareData_.TilePosY = br.ReadInt16();
                squareData_.Tiles = new SimpleTileData[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        SimpleTileData simpleTileData = default(SimpleTileData);
                        simpleTileData.Flags1 = br.ReadByte();
                        simpleTileData.Flags2 = br.ReadByte();
                        SimpleTileData simpleTileData2 = simpleTileData;
                        if (simpleTileData2.Flags2[2])
                        {
                            simpleTileData2.TileColor = br.ReadByte();
                        }
                        if (simpleTileData2.Flags2[3])
                        {
                            simpleTileData2.WallColor = br.ReadByte();
                        }
                        if (simpleTileData2.Flags1[0])
                        {
                            simpleTileData2.TileType = br.ReadUInt16();
                            if (Constants.tileFrameImportant[simpleTileData2.TileType])
                            {
                                simpleTileData2.FrameX = br.ReadInt16();
                                simpleTileData2.FrameY = br.ReadInt16();
                            }
                        }
                        if (simpleTileData2.Flags1[2])
                        {
                            simpleTileData2.WallType = br.ReadUInt16();
                        }
                        if (simpleTileData2.Flags1[3])
                        {
                            simpleTileData2.Liquid = br.ReadByte();
                            simpleTileData2.LiquidType = br.ReadByte();
                        }
                        squareData_.Tiles[i, j] = simpleTileData2;
                    }
                }
                return squareData_;
            }
            protected override void _Write(BinaryWriter bw, SquareData t)
            {
                bw.Write(t.Size);
                if ((t.Size & 0x8000u) != 0)
                {
                    bw.Write((byte)t.ChangeType);
                }
                bw.Write(t.TilePosX);
                bw.Write(t.TilePosY);
                for (int i = 0; i < t.Height; i++)
                {
                    for (int j = 0; j < t.Width; j++)
                    {
                        SimpleTileData simpleTileData = t.Tiles[i, j];
                        bw.Write(simpleTileData.Flags1);
                        bw.Write(simpleTileData.Flags2);
                        if (simpleTileData.Flags2[2])
                        {
                            bw.Write(simpleTileData.TileColor);
                        }
                        if (simpleTileData.Flags2[3])
                        {
                            bw.Write(simpleTileData.WallColor);
                        }
                        if (simpleTileData.Flags1[0])
                        {
                            bw.Write(simpleTileData.TileType);
                            if (Constants.tileFrameImportant[simpleTileData.TileType])
                            {
                                bw.Write(simpleTileData.FrameX);
                                bw.Write(simpleTileData.FrameY);
                            }
                        }
                        if (simpleTileData.Flags1[2])
                        {
                            bw.Write(simpleTileData.WallType);
                        }
                        if (simpleTileData.Flags1[3])
                        {
                            bw.Write(simpleTileData.Liquid);
                            bw.Write(simpleTileData.LiquidType);
                        }
                    }
                }
            }
        }
    }
}

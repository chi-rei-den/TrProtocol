using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Ambience;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.GameContent.NetModules.NetTeleportPylonModule;
using static Terraria.GameContent.NetModules.NetBestiaryModule;

namespace Delphinus
{
    internal static class Serializers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, Vector2 data)
        {
            writer.Write(data.X);
            writer.Write(data.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, Color data)
            => writer.Write(data.packedValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, BitsByte data)
            => writer.Write(data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, WiresUI.Settings.MultiToolMode data)

            => writer.Write((byte)data);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, TileChangeType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, NetworkText data)
            => data.Serialize(writer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, PlayerDeathReason data)
            => data.WriteSelfTo(writer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, PlayerSpawnContext data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, SkyEntityType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, SubPacketType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, TeleportPylonType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, BestiaryUnlockType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, ParticleOrchestraType data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, ParticleOrchestraSettings data)
            => data.Serialize(writer);
        /*
        internal static void Serialize(BinaryWriter writer, ICreativePower data, byte playerSlot)
        {
            switch (data)
            {
            case CreativePowers.DifficultySliderPower p:
                p.Save(writer);
                break;
             case CreativePowers.FarPlacementRangePower p:
                p.Save(Main.player[playerSlot], writer);
                break;
             case CreativePowers.FreezeRainPower p:
                p.Save(writer);
                break;
             case CreativePowers.FreezeTime p:
                p.Save(writer);
                break;
             case CreativePowers.FreezeWindDirectionAndStrength p:
                p.Save(writer);
                break;
            case CreativePowers.GodmodePower p:
                p.Save(Main.player[playerSlot], writer);
                break;
            case CreativePowers.ModifyTimeRate p:
                p.Save(writer);
                break;
            case CreativePowers.SpawnRateSliderPerPlayerPower p:
                p.Save(Main.player[playerSlot], writer);
                break;
            case CreativePowers.StopBiomeSpreadPower p:
                p.Save(writer);
                break;
            }
        }
        */
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, TileEntity data)
            => TileEntity.Write(writer, data, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, short[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, ushort[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, float[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i]);
            }
        }

        internal static void Serialize(BinaryWriter writer, NetLiquidData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i].PosX);
                writer.Write(data[i].PosY);
                writer.Write(data[i].Liquid);
                writer.Write(data[i].LiquidType);
            }
        }

        internal static void Serialize(BinaryWriter writer, SimpleTileData[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    var tile = data[i, j];
                    var flags1 = tile.Flags1;
                    var flags2 = tile.Flags2;
                    writer.Write(flags1);
                    writer.Write(flags2);

                    if (flags2[2])
                    {
                        writer.Write(tile.TileColor);
                    }
                    if (flags2[3])
                    {
                        writer.Write(tile.WallColor);
                    }
                    if (flags1[0])
                    {
                        writer.Write(tile.TileType);
                        if (Main.tileFrameImportant[(int)tile.TileType])
                        {
                            writer.Write(tile.FrameX);
                            writer.Write(tile.FrameY);
                        }
                    }
                    if (flags1[2])
                    {
                        writer.Write(tile.WallType);
                    }
                    if (flags1[3])
                    {
                        writer.Write(tile.Liquid);
                        writer.Write(tile.LiquidType);
                    }
                }
            }
        }

        internal static void Serialize(BinaryWriter writer, SectionData data, bool isCompressed)
        {
            if (isCompressed)
            {
                using (var ds = new DeflateStream(writer.BaseStream, CompressionMode.Compress, true))
                {
                    using (var bw = new BinaryWriter(ds))
                    {
                        serialize(bw);
                    }
                }
            }
            else
            {
                serialize(writer);
            }

            void serialize(BinaryWriter bw)
            {
                bw.Write(data.StartX);
                bw.Write(data.StartY);
                bw.Write(data.Width);
                bw.Write(data.Height);
                
                for (int i = 0; i < data.Tiles.Length; i++)
                {
                    serializeTile(bw, data.Tiles[i]);
                }
                
                bw.Write(data.ChestCount);

                for (int i = 0; i < data.ChestCount; i++)
                {
                    var chest = data.Chests[i];
                    bw.Write(chest.ID);
                    bw.Write(chest.TileX);
                    bw.Write(chest.TileY);
                    bw.Write(chest.Name);
                }
                
                bw.Write(data.SignCount);

                for (int i = 0; i < data.SignCount; i++)
                {
                    var sign = data.Signs[i];
                    bw.Write(sign.ID);
                    bw.Write(sign.TileX);
                    bw.Write(sign.TileY);
                    bw.Write(sign.Text);
                }
                
                bw.Write(data.TileEntityCount);

                for (int i = 0; i < data.TileEntityCount; i++)
                {
                    TileEntity.Write(bw, data.TileEntities[i], false);
                }
            }

            void serializeTile(BinaryWriter bw, ComplexTileData tile)
            {
                var flags1 = tile.Flags1;
                var flags2 = tile.Flags2;
                var flags3 = tile.Flags3;
                
                //flags1[6] = tile.Count > 1;
                //flags1[7] = tile.Count > byte.MaxValue;

                bw.Write(flags1);
                // if HasFlag2 flag is true
                if (flags1[0])
                {
                    bw.Write(flags2);
                    // if HasFlag3 flag is true
                    if (flags2[0]) bw.Write(flags3);
                }

                // if HasTile flag is true
                if (flags1[1])
                {
                    // write a byte when this flag is false
                    if (flags1[5])
                        bw.Write(tile.TileType);
                    else
                        bw.Write((byte)tile.TileType);


                    if (Main.tileFrameImportant[tile.TileType])
                    {
                        bw.Write(tile.FrameX);
                        bw.Write(tile.FrameY);
                    }

                    // if HasTileColor flag is true
                    if (flags3[3])
                        bw.Write(tile.TileColor);
                }

                // if HasWall flag is true
                if (flags1[2])
                {
                    bw.Write((byte)tile.WallType);
                    // if HasWallColor flag is true
                    if (flags3[4])
                        bw.Write(tile.WallColor);
                }

                // if Liquid1 or Liquid2 flag is true
                if (flags1[3] || flags1[4])
                    bw.Write(tile.Liquid);

                // write an additional byte if wall type is greater than byte's max
                if (flags3[6])
                {
                    bw.Write((byte)(tile.WallType >> 8));
                }

                if (flags1[6] || flags1[7])
                {
                    if (flags1[7])
                        bw.Write(tile.Count);
                    else
                        bw.Write((byte)tile.Count);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
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
using Terraria.GameContent.NetModules;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;

namespace Delphinus
{
    internal static class Deserializers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte[] DeserializeBytes(BinaryReader reader, int count)
            => reader.ReadBytes(count);

        internal static ushort[] DeserializeUInt16Array(BinaryReader reader, int count)
        {
            var array = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = reader.ReadUInt16();
            }
            return array;
        }

        internal static short[] DeserializeInt16Array(BinaryReader reader, int count)
        {
            var array = new short[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = reader.ReadInt16();
            }
            return array;
        }

        internal static float[] DeserializeSingleArray(BinaryReader reader, int count)
        {
            var array = new float[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = reader.ReadSingle();
            }
            return array;
        }

        internal static NetLiquidData[] DeserializeNetLiquidData(BinaryReader reader, int count)
        {
            var array = new NetLiquidData[count];
            for (int i = 0; i < count; i++)
            {
                array[i].PosX = reader.ReadUInt16();
                array[i].PosY = reader.ReadUInt16();
                array[i].Liquid = reader.ReadByte();
                array[i].LiquidType = reader.ReadByte();
            }
            return array;
        }

        internal static SimpleTileData[,] DeserializeSimpleTileData(BinaryReader reader, int width, int height)
        {
            var array = new SimpleTileData[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var tile = new SimpleTileData();
                    tile.Flags1 = reader.ReadByte();
                    tile.Flags2 = reader.ReadByte();
                    if (tile.Flags2[2])
                    {
                        tile.TileColor = reader.ReadByte();
                    }
                    if (tile.Flags2[3])
                    {
                        tile.WallColor = reader.ReadByte();
                    }
                    if (tile.Flags1[0])
                    {
                        tile.TileType = reader.ReadUInt16();
                        if (Main.tileFrameImportant[(int)tile.TileType])
                        {
                            tile.FrameX = reader.ReadInt16();
                            tile.FrameY = reader.ReadInt16();
                        }
                    }
                    if (tile.Flags1[2])
                    {
                        tile.WallType = reader.ReadUInt16();
                    }
                    if (tile.Flags1[3])
                    {
                        tile.Liquid = reader.ReadByte();
                        tile.LiquidType = reader.ReadByte();
                    }
                    array[i, j] = tile;
                }
            }
            return array;
        }

        internal static SectionData DeserializeSectionData(BinaryReader reader, bool isCompressed)
        {
            if (isCompressed)
            {
                using (var ds = new DeflateStream(reader.BaseStream, CompressionMode.Decompress, true))
                {
                    using (var br = new BinaryReader(ds))
                    {
                        return deserialize(br);
                    }
                }
            }
            else
            {
                return deserialize(reader);
            }

            SectionData deserialize(BinaryReader br)
            {
                var data = new SectionData
                {
                    StartX = br.ReadInt32(),
                    StartY = br.ReadInt32(),
                    Width = br.ReadInt16(),
                    Height = br.ReadInt16(),
                };

                var totalCount = data.Width * data.Height;
                // TODO: reuse this list as a buffer
                var tiles = new List<ComplexTileData>();
                while (totalCount > 0)
                {
                    var tile = deserializeTile(br);
                    tiles.Add(tile);
                    totalCount -= tile.Count + 1;
                }
                data.Tiles = tiles.ToArray();

                data.ChestCount = br.ReadInt16();
                if (data.ChestCount > 8000)
                    throw new Exception("Too many chests!");
                data.Chests = new ChestData[data.ChestCount];
                for (int i = 0; i < data.ChestCount; i++)
                {
                    ref var chest = ref data.Chests[i];
                    chest.ID = br.ReadInt16();
                    chest.TileX = br.ReadInt16();
                    chest.TileY = br.ReadInt16();
                    chest.Name = br.ReadString();
                }

                data.SignCount = br.ReadInt16();
                if (data.SignCount > 1000)
                    throw new Exception("Too many signs!");
                data.Signs = new SignData[data.SignCount];
                for (int i = 0; i < data.SignCount; i++)
                {
                    ref var sign = ref data.Signs[i];
                    sign.ID = br.ReadInt16();
                    sign.TileX = br.ReadInt16();
                    sign.TileY = br.ReadInt16();
                    sign.Text = br.ReadString();
                }

                data.TileEntityCount = br.ReadInt16();
                if (data.TileEntityCount > 1000)
                    throw new Exception("Too many tile entities!");
                data.TileEntities = new TileEntity[data.TileEntityCount];
                for (int i = 0; i < data.TileEntityCount; i++)
                {
                    data.TileEntities[i] = TileEntity.Read(br, false);
                }

                return data;
            }

            ComplexTileData deserializeTile(BinaryReader br)
            {
                var tile = new ComplexTileData();

                tile.Flags1 = br.ReadByte();
                var flags1 = tile.Flags1;
                // if HasFlag2 flag is true
                if (flags1[0])
                {
                    tile.Flags2 = br.ReadByte();
                    var flags2 = tile.Flags2;
                    // if HasFlag3 flag is true
                    if (flags2[0]) tile.Flags3 = br.ReadByte();
                }
                var flags3 = tile.Flags3;

                // if HasTile flag is true
                if (flags1[1])
                {
                    // read a byte when this flag is false
                    tile.TileType = flags1[5] ? br.ReadUInt16() : br.ReadByte();

                    if (Main.tileFrameImportant[tile.TileType])
                    {
                        tile.FrameX = br.ReadInt16();
                        tile.FrameY = br.ReadInt16();
                    }

                    // if HasTileColor flag is true
                    if (flags3[3])
                        tile.TileColor = br.ReadByte();
                }

                // if HasWall flag is true
                if (flags1[2])
                {
                    tile.WallType = br.ReadByte();
                    // if HasWallColor flag is true
                    if (flags3[4])
                        tile.WallColor = br.ReadByte();
                }

                // if Liquid1 or Liquid2 flag is true
                if (flags1[3] || flags1[4])
                    tile.Liquid = br.ReadByte();

                // read the additional byte if wall type is big
                if (flags3[6])
                {
                    tile.WallType = (ushort)((tile.WallType << 8) | br.ReadByte());
                }

                // if HasCountByte or HasCountInt16 flag is true
                if (flags1[6] || flags1[7])
                {
                    tile.Count = flags1[7] ? br.ReadInt16() : br.ReadByte();
                }

                return tile;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 DeserializeVector2(BinaryReader reader)
            => new Vector2(reader.ReadSingle(), reader.ReadSingle());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Color DeserializeColor(BinaryReader reader)
            => new Color((int)reader.ReadByte(), (int)reader.ReadByte(), (int)reader.ReadByte());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static BitsByte DeserializeBitsByte(BinaryReader reader)
            => reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static WiresUI.Settings.MultiToolMode DeserializeMultiToolMode(BinaryReader reader)
            => (WiresUI.Settings.MultiToolMode)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TileChangeType DeserializeTileChangeType(BinaryReader reader)
            => (TileChangeType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static NetworkText DeserializeNetworkText(BinaryReader reader)
            => NetworkText.Deserialize(reader);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PlayerDeathReason DeserializePlayerDeathReason(BinaryReader reader)
            => PlayerDeathReason.FromReader(reader);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PlayerSpawnContext DeserializePlayerSpawnContext(BinaryReader reader)
            => (PlayerSpawnContext)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static SkyEntityType DeserializeSkyEntityType(BinaryReader reader)
            => (SkyEntityType)reader.ReadByte();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static NetTeleportPylonModule.SubPacketType DeserializeSubPacketType(BinaryReader reader)
            => (NetTeleportPylonModule.SubPacketType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TeleportPylonType DeserializeTeleportPylonType(BinaryReader reader)
            => (TeleportPylonType)reader.ReadByte();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]

        internal static NetBestiaryModule.BestiaryUnlockType DeserializeBestiaryUnlockType(BinaryReader reader)
            => (NetBestiaryModule.BestiaryUnlockType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ParticleOrchestraType DeserializeParticleOrchestraType(BinaryReader reader)
            => (ParticleOrchestraType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ParticleOrchestraSettings DeserializeParticleOrchestraSettings(BinaryReader reader)
        {
            var settings = new ParticleOrchestraSettings();
            settings.DeserializeFrom(reader);
            return settings;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ICreativePower DeserializeCreativePowers(BinaryReader reader, byte playerSlot)
        {
            ushort id = reader.ReadUInt16();
            if (!CreativePowerManager.Instance.TryGetPower(id, out var creativePower))
            {
                return null;
            }
            creativePower.DeserializeNetMessage(reader, playerSlot);
            return creativePower;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TileEntity DeserializeTileEntity(BinaryReader reader)
            => TileEntity.Read(reader, true);
    }
}
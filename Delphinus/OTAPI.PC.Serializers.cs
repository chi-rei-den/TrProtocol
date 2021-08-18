using System;
using System.IO;
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
using Terraria.Localization;
using static Terraria.GameContent.NetModules.NetTeleportPylonModule;
using static Terraria.GameContent.NetModules.NetBestiaryModule;

namespace Delphinus
{
    public static class Serializers
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Serialize(BinaryWriter writer, TileEntity data)
            => data.WriteInner(writer, true);

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

        internal static void Serialize(BinaryWriter writer, (ushort, ushort, byte, byte)[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                writer.Write(data[i].Item1);
                writer.Write(data[i].Item2);
                writer.Write(data[i].Item3);
                writer.Write(data[i].Item4);
            }
        }

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
        internal static (ushort, ushort, byte, byte)[] DeserializeNetLiquidData(BinaryReader reader, int count)
        {
            var array = new (ushort, ushort, byte, byte)[count];
            for (int i = 0; i < count; i++)
            {
                array[i].Item1 = reader.ReadUInt16();
                array[i].Item2 = reader.ReadUInt16();
                array[i].Item3 = reader.ReadByte();
                array[i].Item4 = reader.ReadByte();
            }
            return array;
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

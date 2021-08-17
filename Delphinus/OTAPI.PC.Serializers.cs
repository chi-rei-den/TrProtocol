using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Localization;

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
        internal static void Serialize(BinaryWriter writer, MessageID data)
            => writer.Write((byte)data);

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
        internal static void Serialize(BinaryWriter writer, NetModuleType data)
            => writer.Write((byte)data);

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
        internal static NetModuleType DeserializeNetModuleType(BinaryReader reader)
            => (NetModuleType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TileEntity DeserializeTileEntity(BinaryReader reader)
            => TileEntity.Read(reader, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MessageID DeserializeMessageID(BinaryReader reader)
            => (MessageID)reader.ReadByte();
    }
}

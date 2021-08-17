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
    public static class OTAPISerialization
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

        internal static void Serialize(BinaryWriter writer, object data)
            => throw new NotImplementedException();

        internal static byte[] SerializeBytes(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        internal static ushort[] DeserializeUInt16Array(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        internal static short[] DeserializeInt16Array(BinaryReader reader)
        {
            throw new NotImplementedException();
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
        internal static MessageID DeserializeMessageID(BinaryReader reader)
            => (MessageID)reader.ReadByte();
    }
}

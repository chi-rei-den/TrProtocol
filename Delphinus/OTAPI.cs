#if OTAPI

using System;
using System.IO;
using System.Runtime.CompilerServices;
using Delphinus.InternalPackets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace Delphinus
{
    public static class OTAPISerialization
    {
        // Warning: deserializer shouldn't ended with a colon but serializer should do
        const string _DelphinusGenerationConfig_ = @"
{
   ""CustomSerializers"" : {
        ""byte[]"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""ushort[]"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""short[]"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""Vector2"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""Color"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""BitsByte"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""MultiToolMode"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""NetworkText"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""PlayerDeathReason"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""PlayerSpawnContext"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""NetModuleType"" : ""OTAPISerialization.Serialize(writer, {0});"",
        ""MessageID"" : ""OTAPISerialization.Serialize(writer, {0});""
    },
    ""CustomDeserializers"" : {
        ""byte[]"" : ""OTAPISerialization.SerializeBytes(reader)"",
        ""ushort[]"" : ""OTAPISerialization.DeserializeUInt16Array(reader)"",
        ""short[]"" : ""OTAPISerialization.DeserializeInt16Array(reader)"",
        ""Vector2"" : ""OTAPISerialization.DeserializeVector2(reader)"",
        ""Color"" : ""OTAPISerialization.DeserializeColor(reader)"",
        ""BitsByte"" : ""OTAPISerialization.DeserializeBitsByte(reader)"",
        ""MultiToolMode"" : ""OTAPISerialization.DeserializeMultiToolMode(reader)"",
        ""NetworkText"" : ""OTAPISerialization.DeserializeNetworkText(reader)"",
        ""PlayerDeathReason"" : ""OTAPISerialization.DeserializePlayerDeathReason(reader)"",
        ""PlayerSpawnContext"" : ""OTAPISerialization.DeserializePlayerSpawnContext(reader)"",
        ""NetModuleType"" : ""OTAPISerialization.DeserializeNetModuleType(reader)"",
        ""MessageID"" : ""OTAPISerialization.DeserializeMessageID(reader)""
    },
    ""UsingStatements"" : [
        ""using System.IO;"",
        ""using Microsoft.Xna.Framework;"",
        ""using Terraria;"",
        ""using Terraria.Localization;"",
        ""using Terraria.DataStructures;"",
        ""using static Terraria.GameContent.UI.WiresUI.Settings;""
    ]
}
";

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, Vector2 data)
        {
            writer.Write(data.X);
            writer.Write(data.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, MessageID data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, Color data)
            => writer.Write(data.packedValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, BitsByte data)
            => writer.Write(data);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, WiresUI.Settings.MultiToolMode data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, NetworkText data)
            => data.Serialize(writer);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, PlayerDeathReason data)
            => data.WriteSelfTo(writer);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static void Serialize(BinaryWriter writer, PlayerSpawnContext data)
            => writer.Write((byte)data);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static Vector2 DeserializeVector2(BinaryReader reader)
            => new Vector2(reader.ReadSingle(), reader.ReadSingle());

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static Color DeserializeColor(BinaryReader reader)
            => new Color((int)reader.ReadByte(), (int)reader.ReadByte(), (int)reader.ReadByte());

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static BitsByte DeserializeBitsByte(BinaryReader reader)
            => reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static WiresUI.Settings.MultiToolMode DeserializeMultiToolMode(BinaryReader reader)
            => (WiresUI.Settings.MultiToolMode)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static NetworkText DeserializeNetworkText(BinaryReader reader)
            => NetworkText.Deserialize(reader);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static PlayerDeathReason DeserializePlayerDeathReason(BinaryReader reader)
            => PlayerDeathReason.FromReader(reader);

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static PlayerSpawnContext DeserializePlayerSpawnContext(BinaryReader reader)
            => (PlayerSpawnContext)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static NetModuleType DeserializeNetModuleType(BinaryReader reader)
            => (NetModuleType)reader.ReadByte();

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        internal static MessageID DeserializeMessageID(BinaryReader reader)
            => (MessageID)reader.ReadByte();
    }
}

#endif

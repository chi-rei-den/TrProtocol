using System;
using System.IO;
using Delphinus.OTAPI;
using Delphinus.OTAPI.Packets;
using OTAPI;
using Terraria;

namespace OTAPIServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Terraria.Program.OnLaunched += (_, _) =>
            {
                Hooks.MessageBuffer.GetData += (_, args) =>
                {
                    var reader = args.Instance.reader;
                    var pos = args.ReadOffset;
                    var packetID = args.PacketId;
                    reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                    switch (packetID)
                    {
                    case 1:
                        var hello = reader.Deserialize<ClientHelloPacket>();
                        Console.WriteLine(hello.Version);
                        break;
                    case 4:
                        var playerInfo = reader.Deserialize<SyncPlayerPacket>();
                        Console.WriteLine(playerInfo.Name);
                        break;
                    case 20:
                        var square = reader.Deserialize<TileSquarePacket>();
                        Console.WriteLine($"tile data count: {square.Tiles.Length}");
                        break;
                    }

                    reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                };

                Hooks.NetMessage.SendBytes += (_, args) =>
                {
                    using var ms = new MemoryStream(args.Data);
                    using var reader = new BinaryReader(ms);
                    using var ms2 = new MemoryStream();
                    using var writer = new BinaryWriter(ms2);
                    var length = reader.ReadUInt16();
                    var packetID = reader.ReadByte();
                    Console.WriteLine($"len: {length}, id: {packetID}");
                    switch (packetID)
                    {
                    case 10:
                        NetMessage.DecompressTileBlock(args.Data, 3, args.Data.Length - 3);
                        var section = reader.Deserialize<TileSectionPacket>();
                        Console.WriteLine($"tile data count: {section.Data.Tiles.Length}");
                        section.Serialize(writer);
                        args.Data = ms2.ToArray();
                        break;
                    }

                };
            };

            On.Terraria.Main.ctor += (orig, self) =>
            {
                orig(self);
                Terraria.Main.SkipAssemblyLoad = true;
            };
            Terraria.WindowsLaunch.Main(args);
        }
    }
}
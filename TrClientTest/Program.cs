using System;
using System.Net;
using System.Threading;
using TrClient;
using TrProtocol.Models;
using TrProtocol.Packets;
using TrProtocol.Packets.Modules;

namespace TrClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("ip>");
            var ip = Console.ReadLine();
            Console.Write("port>");
            var port = ushort.Parse(Console.ReadLine());
            Console.Write("password>");
            var password = Console.ReadLine();
            Console.Write("curRelaese>");
            client.CurRelease = Console.ReadLine();
            Console.Write("username>");
            client.Username = Console.ReadLine();*/
            for (int i = 0; i < 50; ++i)
                new Thread(() =>
                {
                    re:
                    try
                    {
                        var client = new TClient();
                        var ip = "169.254.14.118";
                        var port = 7777;

                        //ip = "43.248.189.178"; port = 23360;

                        //ip = "127.0.0.1";

                        ip = "219.150.218.20";
                        port = 46319;
                        client.CurRelease = "Terraria248";
                        client.Username = "rabbit";
                        var password = "123456";

                        client.OnChat += (o, t, c) => Console.WriteLine(t);
                        client.OnMessage += (o, t) => Console.WriteLine(t);

                        ShortPosition spawn = default;

                        client.PostSendPlayer += _ =>
                        {
                            Console.WriteLine($"slot {client.PlayerSlot} connected");
                            for (;;)
                            {
                                Console.WriteLine($"slot {client.PlayerSlot} is sending equipment");
                                client.Send(new SyncEquipment {PlayerSlot = client.PlayerSlot});
                                Thread.Sleep(1000);
                            }
                        };

                        client.On<WorldData>(world => spawn = new ShortPosition(world.SpawnX, world.SpawnY));

                        var done = false;

                        client.On<StartPlaying>(_ =>
                        {
                            try
                            {
                                client.Send(new NetTextModuleC2S {Command = "Say", Text = $"/register {password}"});
                                client.Send(new NetTextModuleC2S {Command = "Say", Text = $"/login {password}"});

                                byte[] b = new byte[300];
                                var rnd = new Random();
                                for (;;)
                                {
                                    rnd.NextBytes(b);
                                    client.Send(new NetTextModuleC2S
                                        {Command = "Say", Text = $"a{Convert.ToBase64String(b)}"});
                                }
                            }
                            catch
                            {
                                client.connected = false;
                            }
                        });

                        client.GameLoop(new IPEndPoint(IPAddress.Parse(ip), port), password);
                        goto re;
                    }
                    catch
                    {
                        goto re;
                    }
                }).Start();
        }
    }
}

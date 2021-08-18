using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetTextModule : IPacket
    {
        // Client to Server
        [Condition("!Main.dedServ", "Main.dedServ")]
        public string Command { get; set; }
        [Condition("!Main.dedServ", "Main.dedServ")]
        public string Text { get; set; }

        // Server to Client
        [Condition("Main.dedServ", "!Main.dedServ")]
        public byte PlayerSlot { get; set; }
        [Condition("Main.dedServ", "!Main.dedServ")]
        public NetworkText NetworkText { get; set; }
        [Condition("Main.dedServ", "!Main.dedServ")]
        public Color Color { get; set; }
    }
}

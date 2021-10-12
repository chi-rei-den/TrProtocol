using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetTextModule : IPacket
    {
        // Client to Server
        [C2SOnly]
        public string Command { get; set; }
        [C2SOnly]
        public string Text { get; set; }

        // Server to Client
        [S2COnly]
        public byte PlayerSlot { get; set; }
        [S2COnly]
        public NetworkText NetworkText { get; set; }
        [S2COnly]
        public Color Color { get; set; }
    }
}

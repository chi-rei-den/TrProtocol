using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetTeleportPylonModule : IPacket
    {
        public SubPacketType Type { get; set; }
        [Condition("(byte){{packet}}.Type == 2")]
        public short PosX { get; set; }
        [Condition("(byte){{packet}}.Type == 2")]
        public short PosY { get; set; }
        [Condition("(byte){{packet}}.Type == 2")]
        public TeleportPylonType PylonType { get; set; }
    }
}
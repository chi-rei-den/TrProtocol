using Delphinus.InternalModels;

namespace Delphinus.InternalPackets.Modules
{
    internal class NetBestiaryModule : IPacket
    {
        public BestiaryUnlockType Type { get; set; }
        public short NPCNetID { get; set; }
        [Condition("(byte){{packet}}.Type == 0")]
        public ushort KillCount { get; set; }
    }
}
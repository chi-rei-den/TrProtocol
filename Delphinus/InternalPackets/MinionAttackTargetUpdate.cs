namespace Delphinus.InternalPackets
{
    internal class MinionAttackTargetUpdate : IPacket, IPlayerSlot
    {
        public byte PlayerSlot { get; set; }
        public short MinionAttackTarget { get; set; }
    }
}
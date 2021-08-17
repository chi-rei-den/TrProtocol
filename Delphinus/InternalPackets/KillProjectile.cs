namespace Delphinus.InternalPackets
{
    internal class KillProjectile : IPacket, IProjSlot, IPlayerSlot
    {
        public short ProjSlot { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
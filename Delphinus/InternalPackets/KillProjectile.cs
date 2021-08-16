namespace Delphinus.InternalPackets
{
    internal class KillProjectilePacket : IPacket, IProjSlot, IPlayerSlot
    {
        public MessageID Type => MessageID.KillProjectile;
        public short ProjSlot { get; set; }
        public byte PlayerSlot { get; set; }
    }
}
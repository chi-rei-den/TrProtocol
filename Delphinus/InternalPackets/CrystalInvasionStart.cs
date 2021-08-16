namespace Delphinus.InternalPackets
{
    internal class CrystalInvasionStartPacket : IPacket
    {
        public MessageID Type => MessageID.CrystalInvasionStart;
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
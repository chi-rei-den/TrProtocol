namespace Delphinus.InternalPackets
{
    internal class MurderSomeoneElsesProjectile : IPacket, IOtherPlayerSlot
    {
        public byte OtherPlayerSlot { get; set; }
        public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
        public byte AI1 { get; set; }
    }
}
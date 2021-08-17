namespace Delphinus.InternalPackets
{
    internal class SyncCavernMonsterType : IPacket
    {
        [Arguments("6")]
        public short[] CavernMonsterType { get; set; }
    }
}
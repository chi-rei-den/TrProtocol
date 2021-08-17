namespace Delphinus.InternalPackets
{
    internal class SyncCavernMonsterTypePacket : IPacket
    {
        public MessageID Type => MessageID.SyncCavernMonsterType;
        [Arguments("6")]
        public short[] CavenMonsterType { get; set; }
    }
}
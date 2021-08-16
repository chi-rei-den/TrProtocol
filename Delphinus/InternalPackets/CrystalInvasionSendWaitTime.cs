namespace Delphinus.InternalPackets
{
    internal class CrystalInvasionSendWaitTimePacket : IPacket
    {
        public MessageID Type => MessageID.CrystalInvasionSendWaitTime;
        public int WaitTime { get; set; }
    }
}
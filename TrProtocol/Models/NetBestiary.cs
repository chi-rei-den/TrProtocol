namespace TrProtocol.Models
{
    public partial class NetBestiary
    {
        public BestiaryUnlockType UnlockType { get; set; }
        [BoundWith("MaxNPCID")]
        public short NPCNetID { get; set; }
        public ushort KillCount { get; set; }
    }
}

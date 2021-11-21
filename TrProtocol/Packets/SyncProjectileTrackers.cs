using TrProtocol.Models;

namespace TrProtocol.Packets
{
    public class SyncProjectileTrackers : Packet, IPlayerSlot
    {
        public override MessageID Type => MessageID.SyncProjectileTrackers;

        public byte PlayerSlot { get; set; }
        public TrackedProjectileReference PiggyBankTracker { get; set; }
        public TrackedProjectileReference VoidLensTracker { get; set; }
    }
}

namespace Delphinus.InternalPackets
{
    internal class TogglePartyPacket : IPacket
    {
        public MessageID Type => MessageID.ToggleParty;
    }
}
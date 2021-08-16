namespace Delphinus.InternalPackets
{
    internal class ClientSyncedInventoryPacket : IPacket
    {
        public MessageID Type => MessageID.ClientSyncedInventory;
    }
}
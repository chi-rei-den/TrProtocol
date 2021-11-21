using TrProtocol.Serializers;

namespace TrProtocol.Models
{
    [Serializer(typeof(ByteEnumSerializer<MessageSource>))]
    public enum MessageSource : byte
    {
        Idle,
        Storage,
        ThrownAway,
        PickedUp,
        ChoppedTree,
        ChoppedGemTree,
        Count
    }
}

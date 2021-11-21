using TrProtocol.Serializers;

namespace TrProtocol.Models
{
    [Serializer(typeof(ByteEnumSerializer<BestiaryUnlockType>))]
    public enum BestiaryUnlockType : byte
    {
        Kill,
        Sight,
        Chat
    }
}

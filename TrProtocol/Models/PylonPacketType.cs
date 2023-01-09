using TrProtocol.Serializers;

namespace TrProtocol.Models
{
    [Serializer(typeof(ByteEnumSerializer<PylonPacketType>))]
    public enum PylonPacketType : byte
    {
        PylonWasAdded,
        PylonWasRemoved,
        PlayerRequestsTeleport
    }
}

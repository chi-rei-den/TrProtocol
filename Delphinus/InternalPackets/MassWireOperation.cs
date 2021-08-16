using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class MassWireOperationPacket : IPacket
    {
        public MessageID Type => MessageID.MassWireOperation;
        public short StartX { get; set; }
        public short StartY { get; set; }
        public short EndX { get; set; }
        public short EndY { get; set; }
        public MultiToolMode Mode { get; set; }
    }
}
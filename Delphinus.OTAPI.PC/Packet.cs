using System.IO;

namespace Delphinus
{
    public abstract class Packet
    {
        public abstract MessageID MessageID { get; }
        public bool fromClient;
        public abstract void Deserialize(BinaryReader reader, bool fromClient);
        public abstract void Serialize(BinaryWriter reader, bool fromClient);
    }
}
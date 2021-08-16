using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delphinus.InternalPackets
{
    internal class ClientHelloPacket : IPacket
    {
        public MessageID Type => MessageID.ClientHello;
        public string Version { get; set; }
    }
}

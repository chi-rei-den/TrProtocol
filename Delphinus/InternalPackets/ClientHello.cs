using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delphinus.InternalPackets
{
    internal class ClientHello : IPacket
    {
        public string Version { get; set; }
    }
}

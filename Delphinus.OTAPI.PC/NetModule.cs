using System;
using System.Collections.Generic;
using System.Text;

namespace Delphinus
{
    public abstract class NetModule : Packet
    {
        public abstract NetModuleType NetModuleID { get; }
    }
}

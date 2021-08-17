using System;
using System.Dynamic;
using System.Globalization;

namespace Delphinus.InternalPackets
{
    internal class ChangeDoor : IPacket
    {
        public bool ChangeType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}

﻿using System;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata;

namespace Delphinus.InternalPackets
{
    internal class ChangeDoorPacket : IPacket
    {
        public MessageID Type => MessageID.ChangeDoor;
        public bool ChangeType { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
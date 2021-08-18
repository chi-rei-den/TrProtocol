using System;
using System.Collections.Generic;
using System.IO;

namespace Delphinus.Generator
{
    [Serializable]
    public class GenerationConfig
    {
        public string Namespace { get; set; }
        public Dictionary<string, string> NetModuleSerializers { get; set; }
        public Dictionary<string, string> NetModuleDeserializers { get; set; }
        public Dictionary<string, string> CustomSerializers { get; set; }
        public Dictionary<string, string> CustomDeserializers { get; set; }
        public Dictionary<string, byte> Packets { get; set; }
        public byte NetModulePacketID { get; set; }
        public Dictionary<string, ushort> NetModules { get; set; }
        public List<string> UsingStatements { get; set; }
        public string Writer { get; set; } = nameof(BinaryWriter);
        public string Reader { get; set; } = nameof(BinaryReader);
        public string TypeKind { get; set; } = "class";
        public string BaseType { get; set; }

    }
}
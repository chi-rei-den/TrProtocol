using Delphinus.InternalModels;

namespace Delphinus.InternalPackets
{
    internal class SyncNPC : IPacket
    {
        public short NPCSlot { get; set; }

        public Vector2 Offset { get; set; }
        public Vector2 Velocity { get; set; }
        public ushort Target { get; set; }

        public BitsByte Flags1 { get; set; }
        public BitsByte Flags2 { get; set; }

        private const string varFlags1 = "{{~ $f = packet + '.Flags1' ~}}";
        private const string aiCount =
            "({{$f}} & 0x4) >> 2 + ({{$f}} & 0x8) >> 3 + ({{$f}} & 0x10) >> 4 + ({{$f}} & 0x20) >> 5";
        [Arguments(varFlags1 + aiCount)]
        public float[] AIs { get; set; }

        public short NPCNetID { get; set; }

        [Condition("{{packet}}.Flags2[0]")] public byte PlayerCountOverride { get; set; }
        [Condition("{{packet}}.Flags2[2]")] public float StrengthMultiplier { get; set; }

        [Condition("!{{packet}}.Flags1[7]")] public byte LifeLen { get; set; }

        [Condition("!{{packet}}.Flags1[7]")]
        [Manual(@"
switch ({{packet}}.LifeLen) {
case 1:
    writer.Write((byte){{packet}}.Life);
    break;
case 2:
    writer.Write((short){{packet}}.Life);
    break;
case 4:
    writer.Write((int){{packet}}.Life);
    break;
}
", @"
switch ({{packet}}.LifeLen) {
case 1:
    {{packet}}.Life = reader.ReadByte();
    break;
case 2:
    {{packet}}.Life = reader.ReadInt16();
    break;
case 4:
    {{packet}}.Life = reader.ReadInt32();
    break;
}")]
        public int Life { get; set; }

        private const string varNPCType = "{{~ $t = 'Main.npc[' + packet + '.NPCSlot].type' ~}}";
        private const string isCatchable = "{{$t}} >= 0 && {{$t}} < 668 && Main.npcCatchable[{{$t}}]";
        [Condition(varNPCType + isCatchable)]
        public byte ReleaseOwner { get; set; }
    }
}
namespace Delphinus.InternalPackets
{
    internal class SyncEmoteBubble : IPacket
    {
        public int EmoteID { get; set; }
        public byte AnchorType { get; set; }
        [Condition("{{packet}}.AnchorType != 255")] public byte PlayerSlot { get; set; }
        [Condition("{{packet}}.AnchorType != 255")] public byte HighBitOfPlayerIsAlwaysZero { get; set; }
        [Condition("{{packet}}.AnchorType != 255")] public ushort EmoteLifeTime { get; set; }
        [Condition("{{packet}}.AnchorType != 255")] public byte Emote { get; set; }
        [Condition("{{packet}}.AnchorType != 255 && {{packet}}.Emote < 0")] public short EmoteMetaData { get; set; }
    }
}
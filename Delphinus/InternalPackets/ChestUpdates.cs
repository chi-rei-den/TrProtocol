namespace Delphinus.InternalPackets
{
    internal class ChestUpdates : IPacket
    {
        public byte Operation { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
        //FIXME: DONT NO WHAT IT IS
        public short Unknown1 { get; set; }
        public short Unknown2 { get; set; }
    }
}
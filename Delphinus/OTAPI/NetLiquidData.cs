namespace Delphinus
{
    public struct NetLiquidData
    {
        public ushort PosX { get; set; }
        public ushort PosY { get; set; }
        public byte Liquid { get; set; }
        public byte LiquidType { get; set; }
    }
}
﻿using System;
using TrProtocol.Models;

namespace TrProtocol.Packets
{
    public class WorldData : Packet
    {
        public override MessageID Type => MessageID.WorldData;
        public int Time { get; set; }
        public BitsByte DayAndMoonInfo { get; set; }
        public byte MoonPhase { get; set; }
        public short MaxTileX { get; set; }
        public short MaxTileY { get; set; }
        public short SpawnX { get; set; }
        public short SpawnY { get; set; }
        public short WorldSurface { get; set; }
        public short RockLayer { get; set; }
        public int WorldID { get; set; }
        public string WorldName { get; set; }
        public byte GameMode { get; set; }
        public Guid WorldUniqueID { get; set; }
        public ulong WorldGeneratorVersion { get; set; }
        public byte MoonType { get; set; }
        public byte TreeBackground { get; set; }
        public byte CorruptionBackground { get; set; }
        public byte JungleBackground { get; set; }
        public byte SnowBackground { get; set; }
        public byte HallowBackground { get; set; }
        public byte CrimsonBackground { get; set; }
        public byte DesertBackground { get; set; }
        public byte OceanBackground { get; set; }
        public byte UnknownBackground1 { get; set; }
        public byte UnknownBackground2 { get; set; }
        public byte UnknownBackground3 { get; set; }
        public byte UnknownBackground4 { get; set; }
        public byte UnknownBackground5 { get; set; }
        public byte IceBackStyle { get; set; }
        public byte JungleBackStyle { get; set; }
        public byte HellBackStyle { get; set; }
        public float WindSpeedSet { get; set; }
        public byte CloudNumber { get; set; }
        public int Tree1 { get; set; }
        public int Tree2 { get; set; }
        public int Tree3 { get; set; }
        public byte TreeStyle1 { get; set; }
        public byte TreeStyle2 { get; set; }
        public byte TreeStyle3 { get; set; }
        public byte TreeStyle4 { get; set; }
        public int CaveBack1 { get; set; }
        public int CaveBack2 { get; set; }
        public int CaveBack3 { get; set; }
        public byte CaveBackStyle1 { get; set; }
        public byte CaveBackStyle2 { get; set; }
        public byte CaveBackStyle3 { get; set; }
        public byte CaveBackStyle4 { get; set; }
        public byte ForestTreeTopStyle1 { get; set; }
        public byte ForestTreeTopStyle2 { get; set; }
        public byte ForestTreeTopStyle3 { get; set; }
        public byte ForestTreeTopStyle4 { get; set; }
        public byte CorruptionTreeTopStyle4 { get; set; }
        public byte JungleTreeTopStyle4 { get; set; }
        public byte SnowTreeTopStyle4 { get; set; }
        public byte HallowTreeTopStyle4 { get; set; }
        public byte CrimsonTreeTopStyle4 { get; set; }
        public byte DesertTreeTopStyle4 { get; set; }
        public byte OceanTreeTopStyle4 { get; set; }
        public byte GlowingMushroomTreeTopStyle4 { get; set; }
        public byte UnderworldTreeTopStyle4 { get; set; }
        public float Rain { get; set; }
        public BitsByte EventInfo1 { get; set; }
        public BitsByte EventInfo2 { get; set; }
        public BitsByte EventInfo3 { get; set; }
        public BitsByte EventInfo4 { get; set; }
        public BitsByte EventInfo5 { get; set; }
        public BitsByte EventInfo6 { get; set; }
        public BitsByte EventInfo7 { get; set; }
        public BitsByte EventInfo8 { get; set; }
        public short CopperOreTier { get; set; }
        public short IronOreTier { get; set; }
        public short SilverOreTier { get; set; }
        public short GoldOreTier { get; set; }
        public short CobaltOreTier { get; set; }
        public short MythrilOreTier { get; set; }
        public short AdmantiteOreTier { get; set; }
        public sbyte InvasionType { get; set; }
        public ulong LobbyID { get; set; }
        public float SandstormSeverity { get; set; }
    }
}
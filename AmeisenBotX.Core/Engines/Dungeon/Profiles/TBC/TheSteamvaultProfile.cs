﻿using AmeisenBotX.Common.Math;
using AmeisenBotX.Core.Engines.Dungeon.Enums;
using AmeisenBotX.Core.Engines.Dungeon.Objects;
using AmeisenBotX.Core.Engines.Jobs.Profiles;
using AmeisenBotX.Wow.Objects.Enums;
using System.Collections.Generic;

namespace AmeisenBotX.Core.Engines.Dungeon.Profiles.TBC
{
    public class TheSteamvaultProfile : IDungeonProfile
    {
        public string Author { get; } = "Jannis";

        public string Description { get; } = "Profile for the Dungeon in Outland, made for Level 62 to 66.";

        public DungeonFactionType FactionType { get; } = DungeonFactionType.Neutral;

        public int GroupSize { get; } = 5;

        public WowMapId MapId { get; } = WowMapId.TheSteamvault;

        public int MaxLevel { get; } = 66;

        public string Name { get; } = "[62-66] The Steamvault";

        public List<DungeonNode> Nodes { get; private set; } = new()
        {
            new(new(-14, 7, -4)),
            new(new(-6, 5, -4)),
            new(new(-4, -3, -4)),
            new(new(-5, -11, -5)),
            new(new(-6, -19, -6)),
            new(new(-6, -27, -8)),
            new(new(-5, -34, -11)),
            new(new(-4, -42, -14)),
            new(new(-3, -50, -16)),
            new(new(-2, -57, -19)),
            new(new(-3, -65, -20)),
            new(new(-7, -72, -20)),
            new(new(-10, -79, -20)),
            new(new(-8, -87, -20)),
            new(new(-6, -95, -22)),
            new(new(-2, -102, -22)),
            new(new(1, -109, -22)),
            new(new(5, -116, -21)),
            new(new(9, -123, -21)),
            new(new(13, -130, -22)),
            new(new(17, -137, -22)),
            new(new(20, -144, -23)),
            new(new(21, -152, -22)),
            new(new(22, -160, -22)),
            new(new(22, -168, -22)),
            new(new(22, -176, -22)),
            new(new(22, -184, -22)),
            new(new(23, -192, -22)),
            new(new(23, -200, -22)),
            new(new(23, -208, -22)),
            new(new(24, -216, -23)),
            new(new(24, -224, -23)),
            new(new(24, -232, -23)),
            new(new(24, -240, -22)),
            new(new(25, -248, -23)),
            new(new(25, -256, -23)),
            new(new(25, -264, -22)),
            new(new(24, -272, -23)),
            new(new(24, -280, -21)),
            new(new(27, -286, -17)),
            new(new(31, -293, -14)),
            new(new(36, -298, -11)),
            new(new(43, -302, -10)),
            new(new(50, -306, -9)),
            new(new(57, -309, -8)),
            new(new(65, -310, -8)),
            new(new(73, -312, -8)),
            new(new(81, -313, -8)),
            new(new(89, -316, -8)),
            new(new(91, -318, -8), DungeonNodeType.Use),
            new(new(81, -318, -8), DungeonNodeType.Use),
            new(new(73, -316, -8)),
            new(new(66, -313, -8)),
            new(new(59, -310, -8)),
            new(new(52, -307, -8)),
            new(new(45, -303, -9)),
            new(new(39, -298, -10)),
            new(new(35, -293, -14)),
            new(new(32, -286, -17)),
            new(new(29, -280, -21)),
            new(new(25, -273, -23)),
            new(new(21, -266, -22)),
            new(new(18, -259, -22)),
            new(new(14, -252, -22)),
            new(new(10, -245, -23)),
            new(new(4, -240, -22)),
            new(new(-3, -235, -22)),
            new(new(-9, -230, -21)),
            new(new(-15, -225, -21)),
            new(new(-20, -219, -20)),
            new(new(-24, -212, -20)),
            new(new(-31, -208, -19)),
            new(new(-39, -210, -18)),
            new(new(-46, -213, -19)),
            new(new(-53, -216, -19)),
            new(new(-60, -219, -19)),
            new(new(-67, -223, -18)),
            new(new(-73, -228, -19)),
            new(new(-78, -234, -19)),
            new(new(-81, -241, -18)),
            new(new(-85, -247, -15)),
            new(new(-88, -254, -13)),
            new(new(-90, -262, -11)),
            new(new(-90, -270, -9)),
            new(new(-89, -278, -8)),
            new(new(-89, -286, -8)),
            new(new(-90, -294, -8)),
            new(new(-91, -302, -8)),
            new(new(-92, -310, -8)),
            new(new(-95, -317, -8)),
            new(new(-98, -324, -8)),
            new(new(-103, -330, -8)),
            new(new(-111, -330, -8)),
            new(new(-118, -327, -7)),
            new(new(-125, -324, -7)),
            new(new(-132, -321, -7)),
            new(new(-138, -316, -7)),
            new(new(-144, -311, -7)),
            new(new(-150, -306, -7)),
            new(new(-155, -300, -7)),
            new(new(-160, -293, -8)),
            new(new(-163, -286, -8)),
            new(new(-166, -279, -8)),
            new(new(-169, -272, -8)),
            new(new(-175, -267, -8)),
            new(new(-183, -265, -8)),
            new(new(-191, -264, -8)),
            new(new(-199, -264, -8)),
            new(new(-207, -262, -8)),
            new(new(-214, -259, -8)),
            new(new(-220, -254, -8)),
            new(new(-223, -247, -8)),
            new(new(-226, -240, -8)),
            new(new(-229, -233, -8)),
            new(new(-231, -225, -8)),
            new(new(-233, -217, -8)),
            new(new(-234, -209, -8)),
            new(new(-235, -201, -8)),
            new(new(-238, -194, -7)),
            new(new(-243, -187, -6)),
            new(new(-249, -181, -7)),
            new(new(-255, -176, -7)),
            new(new(-261, -171, -7)),
            new(new(-267, -166, -6)),
            new(new(-273, -161, -6)),
            new(new(-279, -156, -6)),
            new(new(-285, -151, -7)),
            new(new(-291, -146, -8)),
            new(new(-297, -141, -8)),
            new(new(-298, -133, -8)),
            new(new(-296, -125, -8)),
            new(new(-301, -119, -8)),
            new(new(-309, -118, -8)),
            new(new(-317, -118, -8)),
            new(new(-324, -122, -8)),
            new(new(-329, -128, -8)),
            new(new(-329, -118, -8), DungeonNodeType.Use),
            new(new(-327, -136, -8), DungeonNodeType.Use),
            new(new(-320, -140, -8)),
            new(new(-312, -142, -8)),
            new(new(-305, -145, -8)),
            new(new(-297, -147, -8)),
            new(new(-290, -151, -8)),
            new(new(-283, -154, -7)),
            new(new(-276, -158, -6)),
            new(new(-270, -163, -6)),
            new(new(-264, -168, -6)),
            new(new(-258, -173, -7)),
            new(new(-252, -179, -7)),
            new(new(-247, -185, -6)),
            new(new(-243, -192, -7)),
            new(new(-239, -199, -8)),
            new(new(-237, -207, -8)),
            new(new(-236, -215, -8)),
            new(new(-236, -223, -8)),
            new(new(-237, -231, -8)),
            new(new(-234, -238, -8)),
            new(new(-229, -245, -8)),
            new(new(-223, -250, -8)),
            new(new(-217, -255, -8)),
            new(new(-210, -258, -8)),
            new(new(-202, -260, -8)),
            new(new(-194, -263, -8)),
            new(new(-187, -266, -8)),
            new(new(-180, -270, -8)),
            new(new(-174, -276, -8)),
            new(new(-169, -283, -8)),
            new(new(-165, -290, -8)),
            new(new(-166, -298, -8)),
            new(new(-165, -306, -8)),
            new(new(-164, -314, -7)),
            new(new(-157, -318, -8)),
            new(new(-149, -320, -7)),
            new(new(-141, -322, -7)),
            new(new(-133, -324, -7)),
            new(new(-125, -326, -7)),
            new(new(-118, -329, -7)),
            new(new(-112, -334, -8)),
            new(new(-106, -339, -8)),
            new(new(-101, -346, -8)),
            new(new(-99, -354, -8)),
            new(new(-98, -362, -8)),
            new(new(-96, -370, -8)),
            new(new(-96, -378, -8)),
            new(new(-96, -386, -8)),
            new(new(-95, -394, -8)),
            new(new(-95, -402, -8)),
            new(new(-95, -410, -8)),
            new(new(-95, -417, -5)),
            new(new(-95, -424, -2)),
            new(new(-95, -431, 2)),
            new(new(-95, -434, 2), DungeonNodeType.Use),
            new(new(-95, -442, 4), DungeonNodeType.Use),
            new(new(-95, -449, 7)),
            new(new(-95, -457, 8)),
            new(new(-95, -465, 8)),
            new(new(-95, -473, 8)),
            new(new(-98, -480, 8)),
            new(new(-103, -487, 8)),
            new(new(-106, -494, 8)),
            new(new(-99, -497, 8)),
            new(new(-91, -498, 8)),
            new(new(-84, -501, 8)),
            new(new(-85, -509, 8)),
            new(new(-89, -516, 8)),
            new(new(-92, -523, 8)),
            new(new(-92, -531, 8)),
            new(new(-93, -539, 8)),
            new(new(-95, -547, 8)),
            new(new(-95, -555, 8)),
            new(new(-96, -563, 8)),
        };

        public List<int> PriorityUnits { get; } = new();

        public int RequiredItemLevel { get; } = 70;

        public int RequiredLevel { get; } = 62;

        public Vector3 WorldEntry { get; } = new(818, 6947, -81);

        public WowMapId WorldEntryMapId { get; } = WowMapId.Outland;
    }
}
﻿using AmeisenBotX.Core.Engines.Character.Comparators;
using AmeisenBotX.Core.Engines.Character.Talents.Objects;
using AmeisenBotX.Core.Fsm;
using AmeisenBotX.Core.Fsm.Utils.Auras.Objects;
using AmeisenBotX.Wow.Objects.Enums;

namespace AmeisenBotX.Core.Engines.Combat.Classes.Jannis
{
    public class PriestShadow : BasicCombatClass
    {
        public PriestShadow(AmeisenBotInterfaces bot, AmeisenBotFsm stateMachine) : base(bot, stateMachine)
        {
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, shadowformSpell, () => TryCastSpell(shadowformSpell, Bot.Wow.PlayerGuid, true)));
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, powerWordFortitudeSpell, () => TryCastSpell(powerWordFortitudeSpell, Bot.Wow.PlayerGuid, true)));
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, divineSpiritSpell, () => TryCastSpell(divineSpiritSpell, Bot.Wow.PlayerGuid, true)));              //add
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, vampiricEmbraceSpell, () => TryCastSpell(vampiricEmbraceSpell, Bot.Wow.PlayerGuid, true)));
            MyAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, innerFireSpell, () => TryCastSpell(innerFireSpell, Bot.Wow.PlayerGuid, true)));                    //add

            //TargetAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, vampiricTouchSpell, () => TryCastSpell(vampiricTouchSpell, Bot.Wow.TargetGuid, true)));        //bugged
            TargetAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, devouringPlagueSpell, () => TryCastSpell(devouringPlagueSpell, Bot.Wow.TargetGuid, true)));
            TargetAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, shadowWordPainSpell, () => TryCastSpell(shadowWordPainSpell, Bot.Wow.TargetGuid, true)));
            TargetAuraManager.Jobs.Add(new KeepActiveAuraJob(bot.Db, mindBlastSpell, () => TryCastSpell(mindBlastSpell, Bot.Wow.TargetGuid, true)));

            GroupAuraManager.SpellsToKeepActiveOnParty.Add((powerWordFortitudeSpell, (spellName, guid) => TryCastSpell(spellName, guid, true)));
            GroupAuraManager.SpellsToKeepActiveOnParty.Add((divineSpiritSpell, (spellName, guid) => TryCastSpell(spellName, guid, true)));                          //add
        }

        public override string Description => "FCFS based CombatClass for the Shadow Priest spec.";

        public override string Displayname => "Priest Shadow";

        public override bool HandlesMovement => false;

        public override bool IsMelee => false;

        public override IItemComparator ItemComparator { get; set; } = new BasicIntellectComparator(new() { WowArmorType.SHIELDS }, new() { WowWeaponType.ONEHANDED_SWORDS, WowWeaponType.ONEHANDED_MACES, WowWeaponType.ONEHANDED_AXES });

        public override WowRole Role => WowRole.Dps;

        public override TalentTree Talents { get; } = new()
        {
            Tree1 = new()
            {
                { 2, new(1, 2, 5) },
                { 4, new(1, 4, 3) },
                { 5, new(1, 5, 2) },
                { 7, new(1, 7, 3) },
            },
            Tree2 = new(),
            Tree3 = new()
            {
                { 1, new(3, 1, 3) },
                { 2, new(3, 2, 2) },
                { 3, new(3, 3, 5) },
                { 5, new(3, 5, 2) },
                { 6, new(3, 6, 3) },
                { 8, new(3, 8, 5) },
                { 9, new(3, 9, 1) },
                { 10, new(3, 10, 2) },
                { 11, new(3, 11, 2) },
                { 12, new(3, 12, 3) },
                { 14, new(3, 14, 1) },
                { 16, new(3, 16, 3) },
                { 17, new(3, 17, 2) },
                { 18, new(3, 18, 3) },
                { 19, new(3, 19, 1) },
                { 20, new(3, 20, 5) },
                { 21, new(3, 21, 2) },
                { 22, new(3, 22, 3) },
                { 24, new(3, 24, 1) },
                { 25, new(3, 25, 3) },
                { 26, new(3, 26, 5) },
                { 27, new(3, 27, 1) },
            },
        };

        public override bool UseAutoAttacks => true;

        public override string Version => "1.1";

        public override bool WalkBehindEnemy => false;

        public override WowClass WowClass => WowClass.Priest;

        public override void Execute()
        {
            base.Execute();

            if (SelectTarget(TargetProviderDps))
            {
                if (Bot.Player.ManaPercentage < 30
                    && TryCastSpell(dispersionSpell, 0))    //add spell
                {
                    return;
                }
                
                if (Bot.Player.ManaPercentage < 20
                    && TryCastSpell(shadowfiendSpell, Bot.Wow.TargetGuid))      //more cooldown -> lower threshold 
                {
                    return;
                }

                if (Bot.Player.ManaPercentage < 5                               //more cooldown -> lower threshold
                    && TryCastSpell(hymnOfHopeSpell, 0))
                {
                    return;
                }

                if (Bot.Player.HealthPercentage < 60
                    && TryCastSpell(flashHealSpell, Bot.Wow.TargetGuid, true))
                {
                    return;
                }

                if (TryCastSpell(mindBlastSpell, Bot.Wow.TargetGuid, true))     // adjust spell to fit shadow-spec (why is it in the aura-manager?)
                {
                    return;
                }
            }
        }

        public override void OutOfCombatExecute()
        {
            base.OutOfCombatExecute();

            if (HandleDeadPartymembers(resurrectionSpell))
            {
                return;
            }
        }
    }
}
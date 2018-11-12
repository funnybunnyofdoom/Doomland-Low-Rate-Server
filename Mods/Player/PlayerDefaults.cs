// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

// default starting player items / skills
public static class PlayerDefaults
{
    public static Dictionary<Type, int> GetDefaultToolbar()
    {        
        return new Dictionary<Type, int>
        {
        };
    }

    public static Dictionary<Type, int> GetDefaultInventory()
    {
        return new Dictionary<Type, int>
        {
            { typeof(StarterCampItem), 1 },
            { typeof(PropertyClaimItem), 20 },
			{ typeof(PropertyToolItem), 1 },
			{ typeof(StoneAxeItem), 1 },
			{ typeof(WoodenShovelItem), 1 },
			{ typeof(StoneHammerItem), 1 },
			{ typeof(StonePickaxeItem), 1 },
			{ typeof(TomatoItem), 5 },
			{ typeof(BeansItem), 5 },
        };
    }
    
    public static Dictionary<Type, int> GetDefaultCampsiteInventory()
    {
        return new Dictionary<Type, int>
        {
        };
    }

    public static IEnumerable<Type> GetDefaultSkills()
    {
        return new Type[]
        {
            typeof(CarpenterSkill),
            typeof(LoggingSkill),
            typeof(HewingSkill),
            typeof(MasonSkill),
            typeof(MiningSkill),
            typeof(MortaringSkill),
            typeof(ChefSkill),
            typeof(FarmerSkill),
            typeof(DiggingSkill),
            typeof(GatheringSkill),
            typeof(HunterSkill),
            typeof(HuntingSkill),
            typeof(SmithSkill),
            typeof(EngineerSkill),
            typeof(SurvivalistSkill),
            typeof(TailorSkill),
            typeof(SelfImprovementSkill)
        };
    }

    static Dictionary<UserStatType, IDynamicValue> dynamicValuesDictionary = new Dictionary<UserStatType, IDynamicValue>()
    {
        {
            UserStatType.MaxCalories, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(0f, BigStomachSkill.AdditiveStrategy, typeof(BigStomachSkill), Localizer.DoStr("maximum calories")),
                new ConstantValue(3000))
        },
        {
            UserStatType.MaxCarryWeight, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(0f, new BonusUnitsDecoratorStrategy(StrongBackSkill.AdditiveStrategy, "kg", (float val) => val/1000f), typeof(StrongBackSkill), Localizer.DoStr("carry weight")),
                new ConstantValue(ToolbarBackpackInventory.DefaultWeightLimit))
        },
        {
            UserStatType.CalorieRate, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(1f, CalorieEfficiencySkill.MultiplicativeStrategy, typeof(CalorieEfficiencySkill), Localizer.DoStr("calorie cost")),
                new ConstantValue(0))
        },
        {
            UserStatType.DetectionRange, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(0f, PredatoryInstinctsSkill.AdditiveStrategy, typeof(PredatoryInstinctsSkill), Localizer.DoStr("how close you can approach animals")),
                new ConstantValue(0))
        },
    };

    private static SkillModifiedValue CreateSmv(float startValue, ModificationStrategy strategy, Type skillType, LocString benefitsDescription)
    {
        SkillModifiedValue smv = new SkillModifiedValue(startValue, strategy, skillType, benefitsDescription);
        SkillModifiedValueManager.AddSkillBenefit(Localizer.DoStr("You"), smv);
        return smv;
    }

    public static Dictionary<UserStatType, IDynamicValue> GetDefaultDynamicValues()
    {
        return dynamicValuesDictionary;
    }

    public static IEnumerable<Type> GetDefaultBodyparts()
    {
        return new Type[]
        {
            typeof(RoundedFaceItem),
            typeof(BlinkyEyelidsItem),
            typeof(FitTorsoItem),
            typeof(HumanLimbsItem),
            typeof(HipHopHipsItem),
        };
    }

    public static IEnumerable<Type> GetDefaultClothing()
    {
        return new Type[]
        {
			typeof(TrousersItem),
            typeof(HenleyItem),
            typeof(NormalHairItem),
            typeof(TallBootsItem),
            typeof(SquareBeltItem),
        };
    }
}

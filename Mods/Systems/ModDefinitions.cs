// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Housing;
    using Eco.Core.Plugins.Interfaces;
    using System.Collections.Generic;
    using Eco.Gameplay.Systems;

    public class ModDefinitions : IModInit
    {
        public static void Initialize()
        {
            PlayerHousingManager.SetHousingTiers(new HousingTier[] 
            {
                new HousingTier() { TierVal = 0, SoftCap = 2f,  HardCap = 4f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 1, SoftCap = 5f,  HardCap = 10f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 2, SoftCap = 10f, HardCap = 20f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 3, SoftCap = 15f, HardCap = 30f, DiminishingReturnPercent = .5f },
                new HousingTier() { TierVal = 4, SoftCap = 20f, HardCap = 40f, DiminishingReturnPercent = .5f }
            });

            TagAttribute.CategoryToTags = new Dictionary<string, string[]>() 
            {  
                { "Tiers", new[] { "Tier 0", "Tier 1", "Tier 2", "Tier 3", "Tier 4", "Tier 5" } }
            };
        }
    }
}
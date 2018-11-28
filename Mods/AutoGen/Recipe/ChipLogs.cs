namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
	using Eco.Shared.Localization;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(WoodworkingSkill), 3)] 
    public class ChipLogsRecipe : Recipe
    {
        public ChipLogsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<WoodPulpItem>(0.6f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 1, WoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Chip Logs"), typeof(ChipLogsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewLogsRecipe), this.UILink(), 0.05f, typeof(WoodworkingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
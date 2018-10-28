namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(HewingSkill), 1)] 
    public class HewLogsRecipe : Recipe
    {
        public HewLogsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<HewnLogItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewnLogProcessingEfficiencySkill), 2, HewnLogProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Hew Logs", typeof(HewLogsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewLogsRecipe), this.UILink(), 0.05f, typeof(HewnLogProcessingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
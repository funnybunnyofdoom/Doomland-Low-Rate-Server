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
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(FishingSkill), 2)] 
    public class CleanSalmonRecipe : Recipe
    {
        public CleanSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RawFishItem>(5f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SalmonItem>(typeof(FishCleaningEfficiencySkill), 1, FishCleaningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Clean Salmon"), typeof(CleanSalmonRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CleanSalmonRecipe), this.UILink(), 1, typeof(FishCleaningSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}
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

    [RequiresSkill(typeof(FishingSkill), 1)] 
    public class CleanTroutRecipe : Recipe
    {
        public CleanTroutRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RawFishItem>(3f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TroutItem>(typeof(FishCleaningEfficiencySkill), 1, FishCleaningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Clean Trout", typeof(CleanTroutRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CleanTroutRecipe), this.UILink(), 1.5f, typeof(FishCleaningSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}
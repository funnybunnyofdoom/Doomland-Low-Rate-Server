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

    [RequiresSkill(typeof(FishingSkill), 2)] 
    public class ShredKelpRecipe : Recipe
    {
        public ShredKelpRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PlantFibersItem>(7f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<KelpItem>(typeof(FishCleaningEfficiencySkill), 4, FishCleaningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Shred Kelp", typeof(ShredKelpRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShredKelpRecipe), this.UILink(), 1, typeof(FishCleaningSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}
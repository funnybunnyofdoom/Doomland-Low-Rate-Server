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

    [RequiresSkill(typeof(MillProcessingSkill), 3)] 
    public class BeetSugarRecipe : Recipe
    {
        public BeetSugarRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<SugarItem>(3f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetItem>(typeof(MillProcessingEfficiencySkill), 10, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Beet Sugar", typeof(BeetSugarRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeetSugarRecipe), this.UILink(), 5, typeof(MillProcessingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
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

    [RequiresSkill(typeof(MortarProductionSkill), 2)] 
    public class FiberPitchRecipe : Recipe
    {
        public FiberPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(MortarProductionEfficiencySkill), 15, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Fiber Pitch", typeof(FiberPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FiberPitchRecipe), this.UILink(), 0.2f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
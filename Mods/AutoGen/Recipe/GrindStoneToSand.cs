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

    [RequiresSkill(typeof(MortarProductionSkill), 1)] 
    public class GrindStoneToSandRecipe : Recipe
    {
        public GrindStoneToSandRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<SandItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(MortarProductionEfficiencySkill), 5, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Grind Stone To Sand", typeof(GrindStoneToSandRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GrindStoneToSandRecipe), this.UILink(), 5, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}
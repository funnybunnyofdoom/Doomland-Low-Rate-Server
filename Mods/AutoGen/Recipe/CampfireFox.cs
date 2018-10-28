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

    public class CampfireFoxRecipe : Recipe
    {
        public CampfireFoxRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(2f),  
               new CraftingElement<TallowItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FoxCarcassItem>(1)  
            };
            this.Initialize("Campfire Fox", typeof(CampfireFoxRecipe));
            this.CraftMinutes = new ConstantValue(4); 
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
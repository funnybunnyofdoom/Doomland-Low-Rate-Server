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

    public class CampfireSalmonRecipe : Recipe
    {
        public CampfireSalmonRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredFishItem>(2f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SalmonItem>(1)  
            };
            this.Initialize("Campfire Salmon", typeof(CampfireSalmonRecipe));
            this.CraftMinutes = new ConstantValue(5); 
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
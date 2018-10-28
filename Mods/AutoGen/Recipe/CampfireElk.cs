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

    public class CampfireElkRecipe : Recipe
    {
        public CampfireElkRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(7f),  
               new CraftingElement<TallowItem>(4f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ElkCarcassItem>(1)  
            };
            this.Initialize("Campfire Elk", typeof(CampfireElkRecipe));
            this.CraftMinutes = new ConstantValue(10); 
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
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

    public class CampfireHareRecipe : Recipe
    {
        public CampfireHareRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CharredMeatItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HareCarcassItem>(1)  
            };
            this.Initialize("Campfire Hare", typeof(CampfireHareRecipe));
            this.CraftMinutes = new ConstantValue(1); 
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
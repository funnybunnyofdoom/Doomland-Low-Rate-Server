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

    [RequiresSkill(typeof(LargeButcherySkill), 1)] 
    public class ButcherElkRecipe : Recipe
    {
        public ButcherElkRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RawMeatItem>(10f),  
               new CraftingElement<LeatherHideItem>(2f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ElkCarcassItem>(typeof(LargeButcheryEfficiencySkill), 1, LargeButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Butcher Elk", typeof(ButcherElkRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ButcherElkRecipe), this.UILink(), 1, typeof(LargeButcherySpeedSkill));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
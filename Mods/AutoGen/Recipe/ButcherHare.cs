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

    [RequiresSkill(typeof(SmallButcherySkill), 1)] 
    public class ButcherHareRecipe : Recipe
    {
        public ButcherHareRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RawMeatItem>(1f),  
               new CraftingElement<FurPeltItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HareCarcassItem>(typeof(SmallButcheryEfficiencySkill), 1, SmallButcheryEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Butcher Hare", typeof(ButcherHareRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ButcherHareRecipe), this.UILink(), 1, typeof(SmallButcherySpeedSkill));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
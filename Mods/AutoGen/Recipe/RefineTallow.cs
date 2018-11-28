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
    using Eco.Shared.Localization;

    [RequiresSkill(typeof(CulinaryArtsSkill), 2)] 
    public class RefineTallowRecipe : Recipe
    {
        public RefineTallowRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<OilItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TallowItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Refine Tallow"), typeof(RefineTallowRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineTallowRecipe), this.UILink(), 2, typeof(CulinaryArtsSpeedSkill));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}
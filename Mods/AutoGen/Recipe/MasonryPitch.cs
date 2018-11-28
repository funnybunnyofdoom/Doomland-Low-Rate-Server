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

    [RequiresSkill(typeof(MortarProductionSkill), 0)] 
    public class MasonryPitchRecipe : Recipe
    {
        public MasonryPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(2f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(MortarProductionEfficiencySkill), 1, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Masonry Pitch"), typeof(MasonryPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MasonryPitchRecipe), this.UILink(), 0.2f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}
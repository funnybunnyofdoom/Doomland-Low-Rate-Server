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

    [RequiresSkill(typeof(MortarProductionSkill), 4)] 
    public class WheatPitchRecipe : Recipe
    {
        public WheatPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(3f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(MortarProductionEfficiencySkill), 10, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Wheat Pitch"), typeof(WheatPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WheatPitchRecipe), this.UILink(), 0.1f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
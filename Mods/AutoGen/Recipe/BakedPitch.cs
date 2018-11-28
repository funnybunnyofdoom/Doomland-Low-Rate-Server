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

    [RequiresSkill(typeof(MortarProductionSkill), 3)] 
    public class BakedPitchRecipe : Recipe
    {
        public BakedPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(MortarProductionEfficiencySkill), 10, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Baked Pitch"), typeof(BakedPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedPitchRecipe), this.UILink(), 0.1f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
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

    [RequiresSkill(typeof(MortarProductionSkill), 2)] 
    public class PulpPitchRecipe : Recipe
    {
        public PulpPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(MortarProductionEfficiencySkill), 25, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Pulp Pitch", typeof(PulpPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PulpPitchRecipe), this.UILink(), 0.3f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}
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

    [RequiresSkill(typeof(MortarProductionSkill), 1)] 
    public class CharredPitchRecipe : Recipe
    {
        public CharredPitchRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<PitchItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(MortarProductionEfficiencySkill), 20, MortarProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Charred Pitch"), typeof(CharredPitchRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredPitchRecipe), this.UILink(), 0.2f, typeof(MortarProductionSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
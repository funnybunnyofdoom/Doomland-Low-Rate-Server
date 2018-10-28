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

    [RequiresSkill(typeof(MolecularGastronomySkill), 1)] 
    public class RefineFishRecipe : Recipe
    {
        public RefineFishRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<HydrocolloidsItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(MolecularGastronomyEfficiencySkill), 10, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Refine Fish", typeof(RefineFishRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineFishRecipe), this.UILink(), 5, typeof(MolecularGastronomySpeedSkill));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}
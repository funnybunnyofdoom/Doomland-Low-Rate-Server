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
    public class RefineMeatRecipe : Recipe
    {
        public RefineMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<HydrocolloidsItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MolecularGastronomyEfficiencySkill), 10, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Refine Meat", typeof(RefineMeatRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RefineMeatRecipe), this.UILink(), 5, typeof(MolecularGastronomySpeedSkill));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}
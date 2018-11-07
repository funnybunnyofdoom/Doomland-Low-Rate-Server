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

    [RequiresSkill(typeof(PaperSkill), 1)] 
    public class PlantPaperPulpRecipe : Recipe
    {
        public PlantPaperPulpRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<PaperPulpItem>(1f),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(PaperEfficiencySkill), 15, PaperEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Paper Pulp", typeof(LandPaperRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LandPaperRecipe), this.UILink(), 0.25f, typeof(PaperSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
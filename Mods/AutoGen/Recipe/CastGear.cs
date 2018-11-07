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

    [RequiresSkill(typeof(CastingSkill), 2)] 
    public class CastGearRecipe : Recipe
    {
        public CastGearRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GearItem>(2f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(CastingEfficiencySkill), 1, CastingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Cast Gear", typeof(CastGearRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CastGearRecipe), this.UILink(), 1, typeof(CastingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }
}
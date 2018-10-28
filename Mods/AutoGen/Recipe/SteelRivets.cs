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

    [RequiresSkill(typeof(CastingSkill), 4)] 
    public class SteelRivetsRecipe : Recipe
    {
        public SteelRivetsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RivetItem>(3f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(CastingEfficiencySkill), 1, CastingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Steel Rivets", typeof(SteelRivetsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelRivetsRecipe), this.UILink(), 2, typeof(CastingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
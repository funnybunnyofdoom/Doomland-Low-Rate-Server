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

    [RequiresSkill(typeof(LumberWoodworkingSkill), 3)] 
    public class SawBoardsRecipe : Recipe
    {
        public SawBoardsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<BoardItem>(2f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(LumberWoodworkingEfficiencySkill), 4, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Saw Boards"), typeof(SawBoardsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SawBoardsRecipe), this.UILink(), 0.5f, typeof(LumberWoodworkingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}
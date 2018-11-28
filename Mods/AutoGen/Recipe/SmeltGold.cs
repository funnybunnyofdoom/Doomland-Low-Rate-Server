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

    [RequiresSkill(typeof(BasicSmeltingSkill), 4)] 
    public class SmeltGoldRecipe : Recipe
    {
        public SmeltGoldRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GoldIngotItem>(1f),  
               new CraftingElement<TailingsItem>(typeof(BasicSmeltingEfficiencySkill), 2.5f, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GoldOreItem>(typeof(BasicSmeltingEfficiencySkill), 10, BasicSmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Smelt Gold"), typeof(SmeltGoldRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltGoldRecipe), this.UILink(), 0.5f, typeof(BasicSmeltingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
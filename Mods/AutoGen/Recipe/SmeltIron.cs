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

    [RequiresSkill(typeof(BasicSmeltingSkill), 3)] 
    public class SmeltIronRecipe : Recipe
    {
        public SmeltIronRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<IronIngotItem>(1f),  
               new CraftingElement<TailingsItem>(typeof(BasicSmeltingEfficiencySkill), 2.5f, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronOreItem>(typeof(BasicSmeltingEfficiencySkill), 10, BasicSmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Smelt Iron"), typeof(SmeltIronRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltIronRecipe), this.UILink(), 0.5f, typeof(BasicSmeltingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
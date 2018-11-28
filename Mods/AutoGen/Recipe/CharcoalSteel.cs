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

    [RequiresSkill(typeof(AlloySmeltingSkill), 2)] 
    public class CharcoalSteelRecipe : Recipe
    {
        public CharcoalSteelRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<SteelItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(2), 
                new CraftingElement<IronIngotItem>(typeof(AlloySmeltingEfficiencySkill), 5, AlloySmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Charcoal Steel"), typeof(CharcoalSteelRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharcoalSteelRecipe), this.UILink(), 3, typeof(AlloySmeltingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}
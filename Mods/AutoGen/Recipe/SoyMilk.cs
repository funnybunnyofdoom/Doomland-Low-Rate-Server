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

    [RequiresSkill(typeof(MillingSkill), 4)] 
    public class SoyMilkRecipe : Recipe
    {
        public SoyMilkRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<MilkItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeanPasteItem>(typeof(MillProcessingEfficiencySkill), 20, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Soy Milk", typeof(SoyMilkRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoyMilkRecipe), this.UILink(), 0.1f, typeof(MillProcessingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
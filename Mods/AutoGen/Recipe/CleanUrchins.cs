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

    [RequiresSkill(typeof(FishingSkill), 4)] 
    public class CleanUrchinsRecipe : Recipe
    {
        public CleanUrchinsRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<RawFishItem>(1f),  

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<UrchinItem>(typeof(FishCleaningEfficiencySkill), 4, FishCleaningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Clean Urchins"), typeof(CleanUrchinsRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CleanUrchinsRecipe), this.UILink(), 0.2f, typeof(FishCleaningSpeedSkill));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}
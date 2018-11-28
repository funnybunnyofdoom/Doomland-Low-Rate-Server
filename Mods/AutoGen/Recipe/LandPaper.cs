namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
	using Eco.Shared.Localization;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(PaperSkill), 3)] 
    public class LandPaperRecipe : Recipe
    {
        public LandPaperRecipe()
        {
            this.Products = new CraftingElement[]
            {

               new CraftingElement<PropertyClaimItem>(1f),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PaperItem>(typeof(PaperEfficiencySkill), 500, PaperEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize(Localizer.DoStr("Land Claim Paper"), typeof(LandPaperRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LandPaperRecipe), this.UILink(), 0.05f, typeof(PaperSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
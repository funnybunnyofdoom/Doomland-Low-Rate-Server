namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(FishingSkill), 1)]   
    public partial class FishingPoleRecipe : Recipe
    {
        public FishingPoleRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FishingPoleItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(FishingSkill), 5, FishingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FishingPoleRecipe), Item.Get<FishingPoleItem>().UILink(), 5, typeof(FishingSkill));    
            this.Initialize("Fishing Pole", typeof(FishingPoleRecipe));

            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }


}
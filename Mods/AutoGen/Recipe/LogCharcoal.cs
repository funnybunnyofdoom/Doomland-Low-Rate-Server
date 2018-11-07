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

    [RequiresSkill(typeof(MetalworkingSkill), 2)]   
    public partial class LogCharcoalRecipe : Recipe
    {
        public LogCharcoalRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(SteelworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharcoalRecipe), Item.Get<CharcoalItem>().UILink(), 1, typeof(MetalworkingSpeedSkill));    
            this.Initialize("Charcoal", typeof(CharcoalRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }
}
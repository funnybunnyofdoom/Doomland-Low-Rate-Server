namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    

    [Serialized]
    public partial class StockpileItem :
        WorldObjectItem<StockpileObject> 
    {
        public override string FriendlyName { get { return "Stockpile"; } } 
        public override string Description  { get { return  "Designates a 5x5x5 area as storage for large items."; } }

        static StockpileItem()
        {
            
        }

        
    }


    public partial class StockpileRecipe : Recipe
    {
        public StockpileRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StockpileItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 10, BasicCraftingEfficiencySkill.MultiplicativeStrategy),                                                                   
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StockpileRecipe), this.UILink(), 2f, typeof(BasicCraftingSpeedSkill));
            this.Initialize("Stockpile", typeof(StockpileRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
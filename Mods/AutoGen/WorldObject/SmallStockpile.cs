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
    public partial class SmallStockpileItem :
        WorldObjectItem<SmallStockpileObject> 
    {
        public override string FriendlyName { get { return "Small Stockpile"; } } 
        public override string Description  { get { return  "Designates a 3x3x3 area as storage for large items."; } }

        static SmallStockpileItem()
        {
            
        }

        
    }


    public partial class SmallStockpileRecipe : Recipe
    {
        public SmallStockpileRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SmallStockpileItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 5, BasicCraftingEfficiencySkill.MultiplicativeStrategy),                                                                      
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmallStockpileRecipe), this.UILink(), 1f, typeof(BasicCraftingSpeedSkill));
            this.Initialize("Small Stockpile", typeof(SmallStockpileRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
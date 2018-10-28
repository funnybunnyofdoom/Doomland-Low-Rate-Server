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

    public partial class ArrowRecipe : Recipe
    {
        public ArrowRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ArrowItem>(4),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(1)    
            };
            this.CraftMinutes = new ConstantValue(0.1f);
            this.Initialize("Arrow", typeof(ArrowRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


    [Serialized]
    [Weight(10)]      
    [Fuel(500)][Tag("Fuel")]          
    [Currency]                                              
    public partial class ArrowItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Arrow"; } } 
        public override string Description { get { return "Use with the bow to hunt for food (or amaze your friends by shooting apples off of their heads)."; } }

    }

}
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

    [RequiresSkill(typeof(WoodworkingSkill), 0)]   
    public partial class BoardRecipe : Recipe
    {
        public BoardRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(2),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 4, WoodworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoardRecipe), Item.Get<BoardItem>().UILink(), 0.5f, typeof(WoodworkingSpeedSkill));    
            this.Initialize("Board", typeof(BoardRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Fuel(2000)][Tag("Fuel")]          
    [Currency]                                              
    public partial class BoardItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Board"; } } 
        public override string Description { get { return "Can be used in simple crafts, or used to create workbenches."; } }

    }

}
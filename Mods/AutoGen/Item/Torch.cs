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

    public partial class TorchRecipe : Recipe
    {
        public TorchRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TorchItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 2, BasicCraftingEfficiencySkill.MultiplicativeStrategy),    
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TorchRecipe), this.UILink(), 0.5f, typeof(BasicCraftingSpeedSkill));
            this.Initialize("Torch", typeof(TorchRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Fuel(1000)][Tag("Fuel")]          
    [Currency]                                              
    public partial class TorchItem :
    ToolItem                        
    {
        public override string FriendlyName { get { return "Torch"; } } 
        public override string Description { get { return "A little bit of light to help beat back the night."; } }

    }

}
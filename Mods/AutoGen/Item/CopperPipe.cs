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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    [RequiresSkill(typeof(MetalworkingSkill), 1)]   
    public partial class CopperPipeRecipe : Recipe
    {
        public CopperPipeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CopperPipeItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(typeof(MetalworkingEfficiencySkill), 2, MetalworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperPipeRecipe), Item.Get<CopperPipeItem>().UILink(), 2, typeof(MetalworkingSpeedSkill));    
            this.Initialize("Copper Pipe", typeof(CopperPipeRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(MetalworkingEfficiencySkill), 1)]   
    public partial class CopperPipeBlock :
        PipeBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(CopperPipeItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(2000)]      
    [Currency]                                              
    public partial class CopperPipeItem :
    BlockItem<CopperPipeBlock>
    {
        public override string FriendlyName { get { return "Copper Pipe"; } } 
        public override string Description { get { return "A pipe for transporting liquids."; } }

    }

}
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

    [RequiresSkill(typeof(PetrolRefiningSkill), 1)]   
    public partial class GasolineRecipe : Recipe
    {
        public GasolineRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GasolineItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PetroleumItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GasolineRecipe), Item.Get<GasolineItem>().UILink(), 2, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Gasoline", typeof(GasolineRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(PetrolRefiningEfficiencySkill), 1)]   
    public partial class GasolineBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(GasolineItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [Fuel(100000)][Tag("Fuel")]          
    [Currency]                                              
    public partial class GasolineItem :
    BlockItem<GasolineBlock>
    {
        public override string FriendlyName { get { return "Gasoline"; } } 
        public override string FriendlyNamePlural { get { return "Gasoline"; } } 
        public override string Description { get { return "Refined petroleum useful for fueling machines and generators."; } }

    }

}
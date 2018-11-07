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

    [RequiresSkill(typeof(PetrolRefiningSkill), 0)]   
    public partial class BarrelRecipe : Recipe
    {
        public BarrelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BarrelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BarrelRecipe), Item.Get<BarrelItem>().UILink(), 1, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Barrel", typeof(BarrelRecipe));

            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(PetrolRefiningEfficiencySkill), 0)]   
    public partial class BarrelBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(BarrelItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(2000)]      
    [Currency]                                              
    public partial class BarrelItem :
    BlockItem<BarrelBlock>
    {
        public override string FriendlyName { get { return "Barrel"; } } 
        public override string Description { get { return "A metal barrel for carrying liquids."; } }

    }

}
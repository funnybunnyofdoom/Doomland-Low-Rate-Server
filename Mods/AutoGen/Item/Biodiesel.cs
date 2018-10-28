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

    [RequiresSkill(typeof(PetrolRefiningSkill), 2)]   
    public partial class BiodieselRecipe : Recipe
    {
        public BiodieselRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BiodieselItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TallowItem>(typeof(PetrolRefiningEfficiencySkill), 10, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BiodieselRecipe), Item.Get<BiodieselItem>().UILink(), 2, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Biodiesel", typeof(BiodieselRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }

    [Serialized]
    [Solid]
    [RequiresSkill(typeof(PetrolRefiningEfficiencySkill), 2)]   
    public partial class BiodieselBlock :
        PickupableBlock      
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(BiodieselItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [Fuel(80000)][Tag("Fuel")]          
    [Currency]                                              
    public partial class BiodieselItem :
    BlockItem<BiodieselBlock>
    {
        public override string FriendlyName { get { return "Biodiesel"; } } 
        public override string FriendlyNamePlural { get { return "Biodiesel"; } } 
        public override string Description { get { return "A vegetable or animal fat-based diesel fuel."; } }

    }

}
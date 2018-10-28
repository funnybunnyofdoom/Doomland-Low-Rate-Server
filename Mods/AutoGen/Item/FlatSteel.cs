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

    [RequiresSkill(typeof(SteelworkingSkill), 3)]   
    public partial class FlatSteelRecipe : Recipe
    {
        public FlatSteelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FlatSteelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 2, SteelworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<EpoxyItem>(typeof(SteelworkingEfficiencySkill), 1, SteelworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FlatSteelRecipe), Item.Get<FlatSteelItem>().UILink(), 5, typeof(SteelworkingSpeedSkill));    
            this.Initialize("Flat Steel", typeof(FlatSteelRecipe));

            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(4)]                                          
    [RequiresSkill(typeof(SteelworkingEfficiencySkill), 3)]   
    public partial class FlatSteelBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(FlatSteelItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Currency]                                              
    [ItemTier(4)]                                      
    public partial class FlatSteelItem :
    BlockItem<FlatSteelBlock>
    {
        public override string FriendlyName { get { return "Flat Steel"; } } 
        public override string Description { get { return "Coated with a layer of epoxy, this steel refuses to rust."; } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(FlatSteelStacked1Block),
            typeof(FlatSteelStacked2Block),
            typeof(FlatSteelStacked3Block),
            typeof(FlatSteelStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class FlatSteelStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class FlatSteelStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class FlatSteelStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class FlatSteelStacked4Block : PickupableBlock { } //Only a wall if it's all 4 FlatSteel
}
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

    [RequiresSkill(typeof(SteelworkingSkill), 2)]   
    public partial class CorrugatedSteelRecipe : Recipe
    {
        public CorrugatedSteelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CorrugatedSteelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 2, SteelworkingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CorrugatedSteelRecipe), Item.Get<CorrugatedSteelItem>().UILink(), 2, typeof(SteelworkingSpeedSkill));    
            this.Initialize("Corrugated Steel", typeof(CorrugatedSteelRecipe));

            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [Tier(3)]                                          
    [RequiresSkill(typeof(SteelworkingEfficiencySkill), 2)]   
    public partial class CorrugatedSteelBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(CorrugatedSteelItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Currency]                                              
    [ItemTier(3)]                                      
    public partial class CorrugatedSteelItem :
    BlockItem<CorrugatedSteelBlock>
    {
        public override string FriendlyName { get { return "Corrugated Steel"; } } 
        public override string Description { get { return "Especially useful for industrial buildings."; } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(CorrugatedSteelStacked1Block),
            typeof(CorrugatedSteelStacked2Block),
            typeof(CorrugatedSteelStacked3Block),
            typeof(CorrugatedSteelStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class CorrugatedSteelStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class CorrugatedSteelStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class CorrugatedSteelStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class CorrugatedSteelStacked4Block : PickupableBlock { } //Only a wall if it's all 4 CorrugatedSteel
}
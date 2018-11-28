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

    [RequiresSkill(typeof(CementSkill), 1)]   
    public partial class ReinforcedConcreteRecipe : Recipe
    {
        public ReinforcedConcreteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ReinforcedConcreteItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(CementProductionEfficiencySkill), 1, CementProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<RebarItem>(typeof(CementProductionEfficiencySkill), 2, CementProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ReinforcedConcreteRecipe), Item.Get<ReinforcedConcreteItem>().UILink(), 2, typeof(CementProductionSpeedSkill));    
            this.Initialize(Localizer.DoStr("Reinforced Concrete"), typeof(ReinforcedConcreteRecipe));

            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(3)]                                          
    [RequiresSkill(typeof(CementProductionEfficiencySkill), 1)]   
    public partial class ReinforcedConcreteBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Currency]                                              
    [ItemTier(3)]                                      
    public partial class ReinforcedConcreteItem :
    BlockItem<ReinforcedConcreteBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Reinforced Concrete"); } } 
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Reinforced Concrete"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A study construction material poured around a latice of rebar."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(ReinforcedConcreteStacked1Block),
            typeof(ReinforcedConcreteStacked2Block),
            typeof(ReinforcedConcreteStacked3Block),
            typeof(ReinforcedConcreteStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class ReinforcedConcreteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class ReinforcedConcreteStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class ReinforcedConcreteStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class ReinforcedConcreteStacked4Block : PickupableBlock { } //Only a wall if it's all 4 ReinforcedConcrete
}
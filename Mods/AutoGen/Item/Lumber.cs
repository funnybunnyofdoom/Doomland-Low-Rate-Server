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

    [RequiresSkill(typeof(LumberSkill), 1)]   
    public partial class LumberRecipe : Recipe
    {
        public LumberRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(),          

            new CraftingElement<WoodPulpItem>(3)
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(LumberProcessingEfficiencySkill), 10, LumberProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LumberRecipe), Item.Get<LumberItem>().UILink(), 1, typeof(LumberProcessingSpeedSkill));    
            this.Initialize(Localizer.DoStr("Lumber"), typeof(LumberRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(2)]                                          
    [RequiresSkill(typeof(LumberProcessingEfficiencySkill), 1)]   
    public partial class LumberBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(LumberItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Fuel(4000)][Tag("Fuel")]          
    [ResourcePile]                                          
    [Currency]                                              
    [ItemTier(2)]                                      
    public partial class LumberItem :
    BlockItem<LumberBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lumber"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Can be fashioned into various usable equipment."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(LumberStacked1Block),
            typeof(LumberStacked2Block),
            typeof(LumberStacked3Block),
            typeof(LumberStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class LumberStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class LumberStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class LumberStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class LumberStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Lumber
}
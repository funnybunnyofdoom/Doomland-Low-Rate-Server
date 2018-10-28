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

    [RequiresSkill(typeof(GlassworkingSkill), 1)]   
    public partial class FramedGlassRecipe : Recipe
    {
        public FramedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FramedGlassItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(GlassProductionEfficiencySkill), 10, GlassProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(GlassProductionEfficiencySkill), 6, GlassProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FramedGlassRecipe), Item.Get<FramedGlassItem>().UILink(), 1, typeof(GlassProductionSpeedSkill));    
            this.Initialize("Framed Glass", typeof(FramedGlassRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(4)]                                          
    [RequiresSkill(typeof(GlassProductionEfficiencySkill), 1)]   
    public partial class FramedGlassBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(FramedGlassItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Currency]                                              
    [ItemTier(4)]                                      
    public partial class FramedGlassItem :
    BlockItem<FramedGlassBlock>
    {
        public override string FriendlyName { get { return "Framed Glass"; } } 
        public override string FriendlyNamePlural { get { return "Framed Glass"; } } 
        public override string Description { get { return "A transparent, solid material useful for more than just windows."; } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(FramedGlassStacked1Block),
            typeof(FramedGlassStacked2Block),
            typeof(FramedGlassStacked3Block),
            typeof(FramedGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class FramedGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class FramedGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class FramedGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class FramedGlassStacked4Block : PickupableBlock { } //Only a wall if it's all 4 FramedGlass
}
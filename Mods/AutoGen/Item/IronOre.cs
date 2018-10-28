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


    [Serialized]
    [Minable, Solid,Wall]
    public partial class IronOreBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(IronOreItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(30000)]      
    [ResourcePile]                                          
    [Currency]                                              
    public partial class IronOreItem :
    BlockItem<IronOreBlock>
    {
        public override string FriendlyName { get { return "Iron Ore"; } } 
        public override string FriendlyNamePlural { get { return "Iron Ore"; } } 
        public override string Description { get { return "Unrefined ore with traces of iron."; } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
            typeof(IronOreStacked1Block),
            typeof(IronOreStacked2Block),
            typeof(IronOreStacked3Block),
            typeof(IronOreStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class IronOreStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class IronOreStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class IronOreStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class IronOreStacked4Block : PickupableBlock { } //Only a wall if it's all 4 IronOre
}
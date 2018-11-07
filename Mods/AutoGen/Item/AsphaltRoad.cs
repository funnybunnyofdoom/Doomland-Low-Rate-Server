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

    [RequiresSkill(typeof(RoadConstructionSkill), 3)]   
    public partial class AsphaltRoadRecipe : Recipe
    {
        public AsphaltRoadRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AsphaltRoadItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(RoadConstructionEfficiencySkill), 1, RoadConstructionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(RoadConstructionEfficiencySkill), 1, RoadConstructionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AsphaltRoadRecipe), Item.Get<AsphaltRoadItem>().UILink(), 1, typeof(RoadConstructionSkill));    
            this.Initialize("Asphalt Road", typeof(AsphaltRoadRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [Road(1)]                                          
    [UsesRamp(typeof(AsphaltRoadWorldObjectBlock))]              
    [RequiresSkill(typeof(RoadConstructionEfficiencySkill), 3)]   
    public partial class AsphaltRoadBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(AsphaltRoadItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(10000)]      
    [MakesRoads]                                            
    public partial class AsphaltRoadItem :
    RoadItem<AsphaltRoadBlock>
    {
        public override string FriendlyName { get { return "Asphalt Road"; } } 
        public override string Description { get { return "A paved surface constructed with asphalt and concrete. It's durable and extremely efficient for any wheeled vehicle."; } }

    }

}
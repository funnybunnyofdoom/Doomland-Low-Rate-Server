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

    [RequiresSkill(typeof(RoadConstructionSkill), 2)]   
    public partial class StoneRoadRecipe : Recipe
    {
        public StoneRoadRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StoneRoadItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(RoadConstructionEfficiencySkill), 8, RoadConstructionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PitchItem>(typeof(RoadConstructionEfficiencySkill), 4, RoadConstructionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneRoadRecipe), Item.Get<StoneRoadItem>().UILink(), 2, typeof(RoadConstructionSkill));    
            this.Initialize(Localizer.DoStr("Stone Road"), typeof(StoneRoadRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }

    [Serialized]
    [Solid, Constructed,Wall]
    [Road(1)]                                          
    [UsesRamp(typeof(StoneRoadWorldObjectBlock))]              
    [RequiresSkill(typeof(RoadConstructionEfficiencySkill), 2)]   
    public partial class StoneRoadBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(StoneRoadItem); } }    
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [MakesRoads]                                            
    public partial class StoneRoadItem :
    RoadItem<StoneRoadBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stone Road"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A rocky surface formed from smoothed rubble. It's fairly durable and efficient for any wheeled vehicle."); } }

    }

}
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

    [RequiresSkill(typeof(RoadConstructionSkill), 1)]   
    public partial class StoneRampRecipe : Recipe
    {
        public StoneRampRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StoneRampItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(RoadConstructionEfficiencySkill), 20, RoadConstructionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PitchItem>(typeof(RoadConstructionEfficiencySkill), 10, RoadConstructionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneRampRecipe), Item.Get<StoneRampItem>().UILink(), 1, typeof(RoadConstructionSkill));    
            this.Initialize("Stone Ramp", typeof(StoneRampRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }

    [Serialized]
    [Constructed]
    [Road(1)]                                          
    [RequiresSkill(typeof(RoadConstructionEfficiencySkill), 1)]   
    public partial class StoneRampBlock :
        Block            
    {
    }

}
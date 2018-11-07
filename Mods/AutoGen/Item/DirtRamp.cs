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

    [RequiresSkill(typeof(RoadConstructionSkill), 0)]   
    public partial class DirtRampRecipe : Recipe
    {
        public DirtRampRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DirtRampItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<DirtItem>(typeof(RoadConstructionEfficiencySkill), 4, RoadConstructionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(DirtRampRecipe), Item.Get<DirtRampItem>().UILink(), 0.5f, typeof(RoadConstructionSkill));    
            this.Initialize("Dirt Ramp", typeof(DirtRampRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [Serialized]
    [Constructed]
    [Road(1)]                                          
    [RequiresSkill(typeof(RoadConstructionEfficiencySkill), 0)]   
    public partial class DirtRampBlock :
        Block            
    {
    }

}
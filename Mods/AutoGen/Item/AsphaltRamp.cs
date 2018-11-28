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
    public partial class AsphaltRampRecipe : Recipe
    {
        public AsphaltRampRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AsphaltRampItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(RoadConstructionEfficiencySkill), 3, RoadConstructionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(RoadConstructionEfficiencySkill), 3, RoadConstructionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AsphaltRampRecipe), Item.Get<AsphaltRampItem>().UILink(), 5, typeof(RoadConstructionSkill));    
            this.Initialize(Localizer.DoStr("Asphalt Ramp"), typeof(AsphaltRampRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }

    [Serialized]
    [Constructed]
    [Road(1)]                                          
    [RequiresSkill(typeof(RoadConstructionEfficiencySkill), 3)]   
    public partial class AsphaltRampBlock :
        Block            
    {
    }

}
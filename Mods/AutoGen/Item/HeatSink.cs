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

    [RequiresModule(typeof(MachinistTableObject))]        
    [RequiresSkill(typeof(MechanicalEngineeringSkill), 1)]   
    public partial class HeatSinkRecipe : Recipe
    {
        public HeatSinkRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HeatSinkItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 10, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HeatSinkRecipe), Item.Get<HeatSinkItem>().UILink(), 5, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Heat Sink", typeof(HeatSinkRecipe));

            CraftingComponent.AddRecipe(typeof(ShaperObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class HeatSinkItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Heat Sink"; } } 
        public override string Description { get { return "A copper plate to draw and disperse heat."; } }

    }

}
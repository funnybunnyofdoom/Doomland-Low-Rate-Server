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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 3)]   
    public partial class RadiatorRecipe : Recipe
    {
        public RadiatorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RadiatorItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HeatSinkItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CopperWiringItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RadiatorRecipe), Item.Get<RadiatorItem>().UILink(), 4, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Radiator", typeof(RadiatorRecipe));

            CraftingComponent.AddRecipe(typeof(ElectricStampingPressObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class RadiatorItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Radiator"; } } 
        public override string Description { get { return "A heat sink that uses liquid running through copper fins to disperse heat build-up."; } }

    }

}
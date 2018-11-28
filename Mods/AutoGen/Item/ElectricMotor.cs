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

    [RequiresSkill(typeof(ElectronicEngineeringSkill), 3)]   
    public partial class ElectricMotorRecipe : Recipe
    {
        public ElectricMotorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElectricMotorItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperWiringItem>(typeof(ElectronicEngineeringEfficiencySkill), 10, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 10, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElectricMotorRecipe), Item.Get<ElectricMotorItem>().UILink(), 5, typeof(ElectronicEngineeringSpeedSkill));    
            this.Initialize(Localizer.DoStr("Electric Motor"), typeof(ElectricMotorRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class ElectricMotorItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Electric Motor"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A motor."); } }

    }

}
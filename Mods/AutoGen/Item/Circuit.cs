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
    public partial class CircuitRecipe : Recipe
    {
        public CircuitRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SubstrateItem>(typeof(ElectronicEngineeringEfficiencySkill), 4, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CopperWiringItem>(typeof(ElectronicEngineeringEfficiencySkill), 10, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GoldFlakesItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CircuitRecipe), Item.Get<CircuitItem>().UILink(), 2, typeof(ElectronicEngineeringSpeedSkill));    
            this.Initialize("Circuit", typeof(CircuitRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class CircuitItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Circuit"; } } 
        public override string Description { get { return "A complex electrical component used in advanced electronics."; } }

    }

}
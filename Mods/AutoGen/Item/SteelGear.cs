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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 1)]   
    public partial class SteelGearRecipe : Recipe
    {
        public SteelGearRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelGearItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 3, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelGearRecipe), Item.Get<SteelGearItem>().UILink(), 4, typeof(IndustrialEngineeringSpeedSkill));    
            this.Initialize("Steel Gear", typeof(SteelGearRecipe));

            CraftingComponent.AddRecipe(typeof(ElectricPlanerObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class SteelGearItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Steel Gear"; } } 
        public override string Description { get { return ""; } }

    }

}
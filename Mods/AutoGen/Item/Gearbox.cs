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
    public partial class GearboxRecipe : Recipe
    {
        public GearboxRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GearboxItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GearItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GearboxRecipe), Item.Get<GearboxItem>().UILink(), 5, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize("Gearbox", typeof(GearboxRecipe));

            CraftingComponent.AddRecipe(typeof(ShaperObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class GearboxItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Gearbox"; } } 
        public override string Description { get { return "Provides speed and torque conversions from a rotating power source to another device"; } }

    }

}
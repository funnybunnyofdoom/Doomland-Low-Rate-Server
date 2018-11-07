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

    [RequiresModule(typeof(ShaperObject))]        
    [RequiresSkill(typeof(MechanicalEngineeringSkill), 1)]   
    public partial class BoilerRecipe : Recipe
    {
        public BoilerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoilerItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPlateItem>(typeof(MechanicsAssemblyEfficiencySkill), 20, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoilerRecipe), Item.Get<BoilerItem>().UILink(), 5, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize("Boiler", typeof(BoilerRecipe));

            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class BoilerItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Boiler"; } } 
        public override string Description { get { return ""; } }

    }

}
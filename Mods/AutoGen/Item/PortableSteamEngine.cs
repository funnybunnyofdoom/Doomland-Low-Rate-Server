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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 2)]   
    public partial class PortableSteamEngineRecipe : Recipe
    {
        public PortableSteamEngineRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PortableSteamEngineItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PistonItem>(typeof(MechanicsAssemblyEfficiencySkill), 8, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(MechanicsAssemblyEfficiencySkill), 15, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronPlateItem>(typeof(MechanicsAssemblyEfficiencySkill), 15, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GearItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoilerItem>(typeof(MechanicsAssemblyEfficiencySkill), 4, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PortableSteamEngineRecipe), Item.Get<PortableSteamEngineItem>().UILink(), 20, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize("Portable Steam Engine", typeof(PortableSteamEngineRecipe));

            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }


    [Serialized]
    [Weight(5000)]      
    [Currency]                                              
    public partial class PortableSteamEngineItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Portable Steam Engine"; } } 
        public override string Description { get { return "An engine that generates mechanical power through steam."; } }

    }

}
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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 1)]   
    public partial class SteamTractorPloughRecipe : Recipe
    {
        public SteamTractorPloughRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteamTractorPloughItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPlateItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(MechanicsAssemblyEfficiencySkill), 20, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteamTractorPloughRecipe), Item.Get<SteamTractorPloughItem>().UILink(), 15, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize("Steam Tractor Plough", typeof(SteamTractorPloughRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }


    [Serialized]
    [Weight(10000)]      
    [Currency]                                              
    public partial class SteamTractorPloughItem :
    VehicleToolItem                        
    {
        public override string FriendlyName { get { return "Steam Tractor Plough"; } } 
        public override string Description { get { return "An attachment for the steam tractor that allows for quick ploughing."; } }

    }

}
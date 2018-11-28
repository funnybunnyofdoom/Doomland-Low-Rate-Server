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
    public partial class SteamTractorSowerRecipe : Recipe
    {
        public SteamTractorSowerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteamTractorSowerItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPlateItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronPipeItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteamTractorSowerRecipe), Item.Get<SteamTractorSowerItem>().UILink(), 15, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize(Localizer.DoStr("Steam Tractor Sower"), typeof(SteamTractorSowerRecipe));

            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }


    [Serialized]
    [Weight(10000)]      
    [Currency]                                              
    public partial class SteamTractorSowerItem :
    VehicleToolItem                        
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steam Tractor Sower"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("An attachment for the steam tractor that allows for quick planting of seeds."); } }

    }

}
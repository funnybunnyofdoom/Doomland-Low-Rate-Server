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
    public partial class IronPlateRecipe : Recipe
    {
        public IronPlateRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronPlateItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 4, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronPlateRecipe), Item.Get<IronPlateItem>().UILink(), 5, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Iron Plate", typeof(IronPlateRecipe));

            CraftingComponent.AddRecipe(typeof(ScrewPressObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class IronPlateItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Iron Plate"; } } 
        public override string Description { get { return ""; } }

    }

}
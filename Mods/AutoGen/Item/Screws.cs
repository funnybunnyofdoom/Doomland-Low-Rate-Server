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
    public partial class ScrewsRecipe : Recipe
    {
        public ScrewsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ScrewsItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 2, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ScrewsRecipe), Item.Get<ScrewsItem>().UILink(), 5, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize(Localizer.DoStr("Screws"), typeof(ScrewsRecipe));

            CraftingComponent.AddRecipe(typeof(LatheObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class ScrewsItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Screws"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

    }

}
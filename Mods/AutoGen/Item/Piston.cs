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
    public partial class PistonRecipe : Recipe
    {
        public PistonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PistonItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPipeItem>(typeof(MechanicsComponentsEfficiencySkill), 5, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 5, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PistonRecipe), Item.Get<PistonItem>().UILink(), 4, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize(Localizer.DoStr("Piston"), typeof(PistonRecipe));

            CraftingComponent.AddRecipe(typeof(ScrewPressObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class PistonItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Iron Piston"); } } 
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Iron Pistons"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A moving component that transfers force. Can also function as a valve occasionally."); } }

    }

}
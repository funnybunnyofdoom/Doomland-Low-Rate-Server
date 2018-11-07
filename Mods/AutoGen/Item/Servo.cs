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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 4)]   
    public partial class ServoRecipe : Recipe
    {
        public ServoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ServoItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(typeof(MechanicsComponentsEfficiencySkill), 3, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FiberglassItem>(typeof(MechanicsComponentsEfficiencySkill), 6, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ServoRecipe), Item.Get<ServoItem>().UILink(), 8, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Servo", typeof(ServoRecipe));

            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class ServoItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Servo"; } } 
        public override string Description { get { return "A rotary actuator that allows for control over angular position."; } }

    }

}
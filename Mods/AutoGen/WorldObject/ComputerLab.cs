namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    

    [Serialized]
    public partial class ComputerLabItem :
        WorldObjectItem<ComputerLabObject> 
    {
        public override string FriendlyName { get { return "Computer Lab"; } } 
        public override string Description  { get { return  "A place where you can sit all day and play video games! Or work on expert-level research."; } }

        static ComputerLabItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]
    public partial class ComputerLabRecipe : Recipe
    {
        public ComputerLabRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ComputerLabItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 50, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(IndustrialEngineeringEfficiencySkill), 30, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ConcreteItem>(typeof(IndustrialEngineeringEfficiencySkill), 40, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(260, IndustrialEngineeringSpeedSkill.MultiplicativeStrategy, typeof(IndustrialEngineeringSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ComputerLabRecipe), Item.Get<ComputerLabItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ComputerLabItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Computer Lab", typeof(ComputerLabRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}
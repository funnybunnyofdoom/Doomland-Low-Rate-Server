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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]   
    public partial class AdvancedCombustionEngineRecipe : Recipe
    {
        public AdvancedCombustionEngineRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AdvancedCombustionEngineItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelPlateItem>(typeof(IndustrialEngineeringEfficiencySkill), 30, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<RivetItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PistonItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ValveItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ServoItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<RadiatorItem>(typeof(IndustrialEngineeringEfficiencySkill), 4, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedCombustionEngineRecipe), Item.Get<AdvancedCombustionEngineItem>().UILink(), 10, typeof(IndustrialEngineeringSpeedSkill));    
            this.Initialize(Localizer.DoStr("Advanced Combustion Engine"), typeof(AdvancedCombustionEngineRecipe));

            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class AdvancedCombustionEngineItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Advanced Combustion Engine"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A more advanced version of the normal combustion engine that produces a greater output."); } }

    }

}
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    
    [Serialized]
    [Weight(25000)]  
    public class SkidSteerItem : WorldObjectItem<SkidSteerObject>
    {
        public override string FriendlyName         { get { return "Skid Steer"; } }
        public override string Description          { get { return "A WHAT?"; } }
    }

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 1)] 
    public class SkidSteerRecipe : Recipe
    {
        public SkidSteerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SkidSteerItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<AdvancedCombustionEngineItem>(1),
                new CraftingElement<RubberWheelItem>(4),
                new CraftingElement<RadiatorItem>(2),
                new CraftingElement<SteelAxleItem>(1), 
                new CraftingElement<GearboxItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CelluloseFiberItem>(typeof(IndustrialEngineeringEfficiencySkill), 20, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 40, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(25);

            this.Initialize("Skid Steer", typeof(SkidSteerRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }

}
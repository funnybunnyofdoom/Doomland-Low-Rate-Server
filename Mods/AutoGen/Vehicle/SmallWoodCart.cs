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
    [Weight(5000)]  
    public class SmallWoodCartItem : WorldObjectItem<SmallWoodCartObject>
    {
        public override string FriendlyName         { get { return "Small Wood Cart"; } }
        public override string Description          { get { return "Small wood cart for hauling minimal loads."; } }
    }

    [RequiresSkill(typeof(WoodworkingSkill), 1)] 
    public class SmallWoodCartRecipe : Recipe
    {
        public SmallWoodCartRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SmallWoodCartItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(WoodworkingEfficiencySkill), 10, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 15, WoodworkingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Small Wood Cart", typeof(SmallWoodCartRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]      
    [RequireComponent(typeof(MovableLinkComponent))]        
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]     
    public partial class SmallWoodCartObject : PhysicsWorldObject, IRepresentsItem
    {
        static SmallWoodCartObject()
        {
            WorldObject.AddOccupancy<SmallWoodCartObject>(new List<BlockOccupancy>(0));
        }

        private static Dictionary<Type, float> roadEfficiency = new Dictionary<Type, float>()
        {
            { typeof(DirtRoadBlock), 1 }, { typeof(DirtRoadWorldObjectBlock), 1 },
            { typeof(StoneRoadBlock), 1.2f }, { typeof(StoneRoadWorldObjectBlock), 1.2f },
            { typeof(AsphaltRoadBlock), 1.4f }, { typeof(AsphaltRoadWorldObjectBlock), 1.4f }
        };

        public override string FriendlyName { get { return "Small Wood Cart"; } }
        public Type RepresentedItemType { get { return typeof(SmallWoodCartItem); } }


        private SmallWoodCartObject() { }

        protected override void Initialize()
        {
            base.Initialize();
            
            this.GetComponent<PublicStorageComponent>().Initialize(8, 1400000);           
            this.GetComponent<VehicleComponent>().Initialize(10, 1, roadEfficiency, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(0.5f);           
        }
    }
}
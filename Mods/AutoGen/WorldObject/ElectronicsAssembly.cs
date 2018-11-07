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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                              
    [RequireRoomMaterialTier(2)]        
    public partial class ElectronicsAssemblyObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Electronics Assembly"; } } 

        public virtual Type RepresentedItemType { get { return typeof(ElectronicsAssemblyItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
            this.GetComponent<HousingComponent>().Set(ElectronicsAssemblyItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class ElectronicsAssemblyItem :
        WorldObjectItem<ElectronicsAssemblyObject> 
    {
        public override string FriendlyName { get { return "Electronics Assembly"; } } 
        public override string Description  { get { return  "A set of machinery to create electronics."; } }

        static ElectronicsAssemblyItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
        
    }


    [RequiresSkill(typeof(ElectronicEngineeringSkill), 0)]
    public partial class ElectronicsAssemblyRecipe : Recipe
    {
        public ElectronicsAssemblyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElectronicsAssemblyItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<RivetItem>(typeof(ElectronicEngineeringEfficiencySkill), 10, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(60, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ElectronicsAssemblyRecipe), Item.Get<ElectronicsAssemblyItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ElectronicsAssemblyItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Electronics Assembly", typeof(ElectronicsAssemblyRecipe));
            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }
}
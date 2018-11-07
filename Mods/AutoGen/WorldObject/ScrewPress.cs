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
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                              
    [RequireRoomMaterialTier(1.7f)]        
    public partial class ScrewPressObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Screw Press"; } } 

        public virtual Type RepresentedItemType { get { return typeof(ScrewPressItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
            this.GetComponent<PowerConsumptionComponent>().Initialize(75);                      
            this.GetComponent<PowerGridComponent>().Initialize(5, new MechanicalPower());        


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class ScrewPressItem :
        ModuleItem<ScrewPressObject> 
    {
        public override string FriendlyName { get { return "Screw Press"; } } 
        public override string Description  { get { return  "A set of smoothing and woodworking tools that assist in creating wheels and transportation."; } }

        static ScrewPressItem()
        {
            
        }

        
        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w"), Text.Info(75))); } }  
    }


    [RequiresSkill(typeof(MechanicalEngineeringSkill), 0)]
    public partial class ScrewPressRecipe : Recipe
    {
        public ScrewPressRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ScrewPressItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsAssemblyEfficiencySkill), 50, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, MechanicsAssemblySpeedSkill.MultiplicativeStrategy, typeof(MechanicsAssemblySpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ScrewPressRecipe), Item.Get<ScrewPressItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ScrewPressItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Screw Press", typeof(ScrewPressRecipe));
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }
}
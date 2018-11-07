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
    public partial class LatheObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Lathe"; } } 

        public virtual Type RepresentedItemType { get { return typeof(LatheItem); } } 


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
    public partial class LatheItem :
        ModuleItem<LatheObject> 
    {
        public override string FriendlyName { get { return "Lathe"; } } 
        public override string Description  { get { return  "A set of smoothing and woodworking tools that assist in creating wheels and transportation."; } }

        static LatheItem()
        {
            
        }

        
        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w"), Text.Info(75))); } }  
    }


    [RequiresModule(typeof(ScrewPressObject))]          
    [RequiresSkill(typeof(MechanicalEngineeringSkill), 0)]
    public partial class LatheRecipe : Recipe
    {
        public LatheRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LatheItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronWheelItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronPlateItem>(typeof(MechanicsAssemblyEfficiencySkill), 20, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, MechanicsAssemblySpeedSkill.MultiplicativeStrategy, typeof(MechanicsAssemblySpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(LatheRecipe), Item.Get<LatheItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<LatheItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Lathe", typeof(LatheRecipe));
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }
}
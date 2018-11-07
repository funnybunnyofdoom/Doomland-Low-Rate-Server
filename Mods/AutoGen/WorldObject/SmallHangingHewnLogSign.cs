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
    [RequireComponent(typeof(CustomTextComponent))]              
    [RequireComponent(typeof(MinimapComponent))]                
    public partial class SmallHangingHewnLogSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Small Hanging Hewn Log Sign"; } } 

        public virtual Type RepresentedItemType { get { return typeof(SmallHangingHewnLogSignItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Sign");                                 
            this.GetComponent<CustomTextComponent>().Initialize(700);                                       


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class SmallHangingHewnLogSignItem :
        WorldObjectItem<SmallHangingHewnLogSignObject> 
    {
        public override string FriendlyName { get { return "Small Hanging Hewn Log Sign"; } } 
        public override string Description  { get { return  "A small sign for all of your smaller text needs!"; } }

        static SmallHangingHewnLogSignItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(WoodworkingSkill), 2)]
    public partial class SmallHangingHewnLogSignRecipe : Recipe
    {
        public SmallHangingHewnLogSignRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SmallHangingHewnLogSignItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(WoodworkingEfficiencySkill), 10, WoodworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(SmallHangingHewnLogSignRecipe), Item.Get<SmallHangingHewnLogSignItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<SmallHangingHewnLogSignItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Small Hanging Hewn Log Sign", typeof(SmallHangingHewnLogSignRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
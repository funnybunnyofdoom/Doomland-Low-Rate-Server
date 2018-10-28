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
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(45)]                              
    [RequireRoomMaterialTier(1.5f)]        
    public partial class CurrencyExchangeObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Currency Exchange"; } } 

        public virtual Type RepresentedItemType { get { return typeof(CurrencyExchangeItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Economy");                                 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class CurrencyExchangeItem :
        WorldObjectItem<CurrencyExchangeObject> 
    {
        public override string FriendlyName { get { return "Currency Exchange"; } } 
        public override string Description  { get { return  "Allows players to exchange currency."; } }

        static CurrencyExchangeItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(MetalworkingSkill), 3)]
    public partial class CurrencyExchangeRecipe : Recipe
    {
        public CurrencyExchangeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CurrencyExchangeItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GoldIngotItem>(typeof(MetalworkingEfficiencySkill), 10, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BrickItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LumberItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(30, MetalworkingSpeedSkill.MultiplicativeStrategy, typeof(MetalworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CurrencyExchangeRecipe), Item.Get<CurrencyExchangeItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CurrencyExchangeItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Currency Exchange", typeof(CurrencyExchangeRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
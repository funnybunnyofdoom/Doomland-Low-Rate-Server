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
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class FishTrapObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Fish Trap"; } } 

        public virtual Type RepresentedItemType { get { return typeof(FishTrapItem); } } 


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
    public partial class FishTrapItem :
        WorldObjectItem<FishTrapObject> 
    {
        public override string FriendlyName { get { return "Fish Trap"; } } 
        public override string Description  { get { return  "A trap to catch fish as they swim. It's too small to catch the larger fish. "; } }

        static FishTrapItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(FishingSkill), 3)]
    public partial class FishTrapRecipe : Recipe
    {
        public FishTrapRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FishTrapItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(FishingSkill), 20, FishingSkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, FishingSkill.MultiplicativeStrategy, typeof(FishingSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FishTrapRecipe), Item.Get<FishTrapItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FishTrapItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Fish Trap", typeof(FishTrapRecipe));
            CraftingComponent.AddRecipe(typeof(FisheryObject), this);
        }
    }
}
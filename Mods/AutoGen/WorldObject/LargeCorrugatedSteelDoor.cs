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
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeCorrugatedSteelDoorObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Large Corrugated Steel Door"; } } 

        public virtual Type RepresentedItemType { get { return typeof(LargeCorrugatedSteelDoorItem); } } 


        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class LargeCorrugatedSteelDoorItem :
        WorldObjectItem<LargeCorrugatedSteelDoorObject> 
    {
        public override string FriendlyName { get { return "Large Corrugated Steel Door"; } } 
        public override string Description  { get { return  "A large door."; } }

        static LargeCorrugatedSteelDoorItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(SteelworkingSkill), 2)]
    public partial class LargeCorrugatedSteelDoorRecipe : Recipe
    {
        public LargeCorrugatedSteelDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeCorrugatedSteelDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(30, SteelworkingSpeedSkill.MultiplicativeStrategy, typeof(SteelworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(LargeCorrugatedSteelDoorRecipe), Item.Get<LargeCorrugatedSteelDoorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<LargeCorrugatedSteelDoorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Large Corrugated Steel Door", typeof(LargeCorrugatedSteelDoorRecipe));
            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }
    }
}
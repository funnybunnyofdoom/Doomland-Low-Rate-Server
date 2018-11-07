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
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                              
    public partial class MasonryTableObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override string FriendlyName { get { return "Masonry Table"; } } 

        public virtual Type RepresentedItemType { get { return typeof(MasonryTableItem); } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class MasonryTableItem :
        WorldObjectItem<MasonryTableObject> 
    {
        public override string FriendlyName { get { return "Masonry Table"; } } 
        public override string Description  { get { return  "A workstation for hewing and shaping stone into usable objects."; } }

        static MasonryTableItem()
        {
            
        }

        
    }


    [RequiresSkill(typeof(StoneworkingSkill), 0)]
    public partial class MasonryTableRecipe : Recipe
    {
        public MasonryTableRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MasonryTableItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(StoneworkingEfficiencySkill), 40, StoneworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LogItem>(typeof(StoneworkingEfficiencySkill), 10, StoneworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, StoneworkingSpeedSkill.MultiplicativeStrategy, typeof(StoneworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(MasonryTableRecipe), Item.Get<MasonryTableItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<MasonryTableItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Masonry Table", typeof(MasonryTableRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
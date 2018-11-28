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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class ElkSkypiercerObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elk Skypiercer"); } } 

        public virtual Type RepresentedItemType { get { return typeof(ElkSkypiercerItem); } } 



        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(ElkSkypiercerItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class ElkSkypiercerItem :
        WorldObjectItem<ElkSkypiercerObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elk Skypiercer"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("You can hear the faint cries of Ecko when this mythical elk antler is held aloft."); } }

        static ElkSkypiercerItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 150,                                   
                                                    TypeForRoomLimit = "Decoration", 
                                                    DiminishingReturnPercent = 0.1f    
        };}}
        
    }


    public partial class ElkSkypiercerRecipe : Recipe
    {
        public ElkSkypiercerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElkSkypiercerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
            };
            this.CraftMinutes = new ConstantValue(); 
            this.Initialize(Localizer.DoStr("Elk Skypiercer"), typeof(ElkSkypiercerRecipe));
            CraftingComponent.AddRecipe(typeof(Object), this);
        }
    }
}
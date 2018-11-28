namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(ClothProductionSkill), 2)]   
    public partial class CelluloseFiberRecipe : Recipe
    {
        public CelluloseFiberRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CelluloseFiberItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CelluloseFiberRecipe), Item.Get<CelluloseFiberItem>().UILink(), 2, typeof(ClothProductionSpeedSkill));    
            this.Initialize(Localizer.DoStr("Cellulose Fiber"), typeof(CelluloseFiberRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }


    [Serialized]
    [Weight(100)]      
    [Currency]                                              
    public partial class CelluloseFiberItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Cellulose Fiber"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Created by taking pulped plants and extruding them similarly to synthetic fibers."); } }

    }

}
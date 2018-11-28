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

    [RequiresSkill(typeof(ClothProductionSkill), 1)]   
    public partial class ClothRecipe : Recipe
    {
        public ClothRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ClothRecipe), Item.Get<ClothItem>().UILink(), 2, typeof(ClothProductionSpeedSkill));    
            this.Initialize(Localizer.DoStr("Cloth"), typeof(ClothRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }


    [Serialized]
    [Weight(100)]      
    [Currency]                                              
    public partial class ClothItem :
    Item                                     
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Cloth"); } } 
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Cloth"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A piece of rough cloth made by weaving fibers together."); } }

    }

}
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using System.ComponentModel;

    [RequiresSkill(typeof(FertilizerProductionSkill), 2)]  
    public partial class FiberFillerRecipe : Recipe
    {
        public FiberFillerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FiberFillerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(FertilizerEfficiencySkill), 10, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<DirtItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FiberFillerRecipe), Item.Get<FiberFillerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize(Localizer.DoStr("Fiber Filler"), typeof(FiberFillerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class FiberFillerItem : FertilizerItem<FiberFillerItem>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Fiber Filler"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        static FiberFillerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.1f));
            nutrients.Add(new NutrientElement("Phosphorus", 0.1f));
            nutrients.Add(new NutrientElement("Potassium", 0.1f));
        }
    }
}
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
    public partial class PeltFertilizerRecipe : Recipe
    {
        public PeltFertilizerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PeltFertilizerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FurPeltItem>(typeof(FertilizerEfficiencySkill), 2, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PeltFertilizerRecipe), Item.Get<PeltFertilizerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize("Pelt Fertilizer", typeof(PeltFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class PeltFertilizerItem : FertilizerItem<PeltFertilizerItem>
    {
        public override string FriendlyName { get { return "Pelt Fertilizer"; } }
        public override string Description  { get { return ""; } }

        static PeltFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 4));
            nutrients.Add(new NutrientElement("Phosphorus", 2));
            nutrients.Add(new NutrientElement("Potassium", 2));
        }
    }
}
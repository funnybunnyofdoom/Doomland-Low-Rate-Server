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

    [RequiresSkill(typeof(FertilizerProductionSkill), 3)]  
    public partial class PhosphateFertilizerRecipe : Recipe
    {
        public PhosphateFertilizerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PhosphateFertilizerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CompositeFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(FertilizerEfficiencySkill), 10, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PhosphateFertilizerRecipe), Item.Get<PhosphateFertilizerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize("Phosphate Fertilizer", typeof(PhosphateFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class PhosphateFertilizerItem : FertilizerItem<PhosphateFertilizerItem>
    {
        public override string FriendlyName { get { return "Phosphate Fertilizer"; } }
        public override string Description  { get { return ""; } }

        static PhosphateFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.5f));
            nutrients.Add(new NutrientElement("Phosphorus", 4));
            nutrients.Add(new NutrientElement("Potassium", 0.5f));
        }
    }
}
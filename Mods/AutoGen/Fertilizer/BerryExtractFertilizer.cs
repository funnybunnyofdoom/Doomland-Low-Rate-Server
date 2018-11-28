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
    public partial class BerryExtractFertilizerRecipe : Recipe
    {
        public BerryExtractFertilizerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BerryExtractFertilizerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CompositeFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberryExtractItem>(typeof(FertilizerEfficiencySkill), 4, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BerryExtractFertilizerRecipe), Item.Get<BerryExtractFertilizerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize(Localizer.DoStr("Berry Extract Fertilizer"), typeof(BerryExtractFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class BerryExtractFertilizerItem : FertilizerItem<BerryExtractFertilizerItem>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Berry Extract Fertilizer"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        static BerryExtractFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 1));
            nutrients.Add(new NutrientElement("Phosphorus", 3));
            nutrients.Add(new NutrientElement("Potassium", 7));
        }
    }
}
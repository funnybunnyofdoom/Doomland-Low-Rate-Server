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
    public partial class CamasAshFertilizerRecipe : Recipe
    {
        public CamasAshFertilizerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasAshFertilizerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CharredCamasBulbItem>(typeof(FertilizerEfficiencySkill), 2, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasAshFertilizerRecipe), Item.Get<CamasAshFertilizerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize("Camas Ash Fertilizer", typeof(CamasAshFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class CamasAshFertilizerItem : FertilizerItem<CamasAshFertilizerItem>
    {
        public override string FriendlyName { get { return "Camas Ash Fertilizer"; } }
        public override string Description  { get { return ""; } }

        static CamasAshFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.3f));
            nutrients.Add(new NutrientElement("Phosphorus", 0.7f));
            nutrients.Add(new NutrientElement("Potassium", 2));
        }
    }
}
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

    [RequiresSkill(typeof(FertilizerProductionSkill), 1)]  
    public partial class PulpFillerRecipe : Recipe
    {
        public PulpFillerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PulpFillerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(FertilizerEfficiencySkill), 10, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<DirtItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PulpFillerRecipe), Item.Get<PulpFillerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize(Localizer.DoStr("Pulp Filler"), typeof(PulpFillerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [Weight(500)]  
    [Category("Tool")]
    public partial class PulpFillerItem : FertilizerItem<PulpFillerItem>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Pulp Filler"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        static PulpFillerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.3f));
            nutrients.Add(new NutrientElement("Phosphorus", 0.3f));
            nutrients.Add(new NutrientElement("Potassium", 0.3f));
        }
    }
}
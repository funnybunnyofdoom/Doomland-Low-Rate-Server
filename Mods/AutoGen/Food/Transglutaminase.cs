namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;

    [Serialized]
    [Weight(100)]                                          
    public partial class TransglutaminaseItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Transglutaminase"; } }
        public override string Description                      { get { return "Any enzyme that can be used to bond proteins together."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 10; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MolecularGastronomySkill), 1)]    
    public partial class TransglutaminaseRecipe : Recipe
    {
        public TransglutaminaseRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TransglutaminaseItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(MolecularGastronomyEfficiencySkill), 30, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TransglutaminaseRecipe), Item.Get<TransglutaminaseItem>().UILink(), 20, typeof(MolecularGastronomySpeedSkill)); 
            this.Initialize("Transglutaminase", typeof(TransglutaminaseRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}
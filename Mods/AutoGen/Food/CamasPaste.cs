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
    public partial class CamasPasteItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Camas Paste"; } }
        public override string FriendlyNamePlural               { get { return "Camas Paste"; } } 
        public override string Description                      { get { return "Pulverized camas works as an excellent thickener or flavour enhancer."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 10, Protein = 2, Vitamins = 0};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 2)]    
    public partial class CamasPasteRecipe : Recipe
    {
        public CamasPasteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasPasteItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(MillProcessingEfficiencySkill), 10, MillProcessingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasPasteRecipe), Item.Get<CamasPasteItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Camas Paste", typeof(CamasPasteRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
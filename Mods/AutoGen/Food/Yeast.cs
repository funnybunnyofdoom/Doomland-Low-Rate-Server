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
    public partial class YeastItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Yeast"; } }
        public override string Description                      { get { return "A fungus that acts as an amazing leavening agent."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 8, Vitamins = 7};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class YeastRecipe : Recipe
    {
        public YeastRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<YeastItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SugarItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(YeastRecipe), Item.Get<YeastItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Yeast", typeof(YeastRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
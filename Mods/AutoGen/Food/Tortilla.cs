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
    public partial class TortillaItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tortilla"; } }
        public override string Description                      { get { return "A thin, unleavened flatbread."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 20, Fat = 0, Protein = 10, Vitamins = 0};
        public override float Calories                          { get { return 350; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 2)]    
    public partial class TortillaRecipe : Recipe
    {
        public TortillaRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TortillaItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornmealItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TortillaRecipe), Item.Get<TortillaItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Tortilla", typeof(TortillaRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
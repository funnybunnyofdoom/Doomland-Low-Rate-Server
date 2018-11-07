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
    [Weight(200)]                                          
    public partial class FriedTomatoesItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fried Tomatoes"; } }
        public override string Description                      { get { return "Secret's in the sauce."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 9, Protein = 3, Vitamins = 2};
        public override float Calories                          { get { return 560; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCreationsSkill), 2)]    
    public partial class FriedTomatoesRecipe : Recipe
    {
        public FriedTomatoesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FriedTomatoesItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TomatoItem>(typeof(CampfireCreationsEfficiencySkill), 8, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(CampfireCreationsEfficiencySkill), 5, CampfireCreationsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedTomatoesRecipe), Item.Get<FriedTomatoesItem>().UILink(), 5, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Fried Tomatoes", typeof(FriedTomatoesRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
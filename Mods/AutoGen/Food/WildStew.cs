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
    [Weight(500)]                                          
    public partial class WildStewItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Wild Stew"; } }
        public override string Description                      { get { return "A thick stew made with a variety of vegetables."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 5, Protein = 5, Vitamins = 12};
        public override float Calories                          { get { return 1200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCreationsSkill), 4)]    
    public partial class WildStewRecipe : Recipe
    {
        public WildStewRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WildStewItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(CampfireCreationsEfficiencySkill), 30, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeetItem>(typeof(CampfireCreationsEfficiencySkill), 15, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeansItem>(typeof(CampfireCreationsEfficiencySkill), 20, CampfireCreationsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WildStewRecipe), Item.Get<WildStewItem>().UILink(), 10, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Wild Stew", typeof(WildStewRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
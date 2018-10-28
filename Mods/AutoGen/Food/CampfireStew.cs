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
    public partial class CampfireStewItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Campfire Stew"; } }
        public override string Description                      { get { return "A thick stew chock-full of meat, camas, and corn. A suprisingly good combination."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 9, Protein = 12, Vitamins = 4};
        public override float Calories                          { get { return 1200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCreationsSkill), 4)]    
    public partial class CampfireStewRecipe : Recipe
    {
        public CampfireStewRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CampfireStewItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(CampfireCreationsEfficiencySkill), 30, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CamasBulbItem>(typeof(CampfireCreationsEfficiencySkill), 10, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornItem>(typeof(CampfireCreationsEfficiencySkill), 10, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(CampfireCreationsEfficiencySkill), 3, CampfireCreationsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireStewRecipe), Item.Get<CampfireStewItem>().UILink(), 10, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Campfire Stew", typeof(CampfireStewRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
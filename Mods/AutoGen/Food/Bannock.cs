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
    public partial class BannockItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Bannock"; } }
        public override string Description                      { get { return "A dense whole wheat unleavened bread."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 8, Protein = 3, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCreationsSkill), 2)]    
    public partial class BannockRecipe : Recipe
    {
        public BannockRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BannockItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatItem>(typeof(CampfireCreationsEfficiencySkill), 30, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(CampfireCreationsEfficiencySkill), 3, CampfireCreationsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BannockRecipe), Item.Get<BannockItem>().UILink(), 5, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Bannock", typeof(BannockRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
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
    public partial class FiddleheadSaladItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fiddlehead Salad"; } }
        public override string Description                      { get { return "A myriad of charred plants that make a healthy and odd blend."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 0, Protein = 6, Vitamins = 14};
        public override float Calories                          { get { return 970; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCreationsSkill), 2)]    
    public partial class FiddleheadSaladRecipe : Recipe
    {
        public FiddleheadSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FiddleheadSaladItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiddleheadsItem>(typeof(CampfireCreationsEfficiencySkill), 20, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BeetItem>(typeof(CampfireCreationsEfficiencySkill), 5, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberriesItem>(typeof(CampfireCreationsEfficiencySkill), 20, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TomatoItem>(typeof(CampfireCreationsEfficiencySkill), 5, CampfireCreationsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FiddleheadSaladRecipe), Item.Get<FiddleheadSaladItem>().UILink(), 5, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Fiddlehead Salad", typeof(FiddleheadSaladRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
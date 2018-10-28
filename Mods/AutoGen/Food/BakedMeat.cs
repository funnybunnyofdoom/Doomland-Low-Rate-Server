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
    public partial class BakedMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Baked Meat"; } }
        public override string Description                      { get { return "Evenly baked meat; it might not have the perfect sear but it's good enough."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 17, Protein = 13, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 2)]    
    public partial class BakedMeatRecipe : Recipe
    {
        public BakedMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BakedMeatItem>(),
               
               new CraftingElement<TallowItem>(1) 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedMeatRecipe), Item.Get<BakedMeatItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize("Baked Meat", typeof(BakedMeatRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
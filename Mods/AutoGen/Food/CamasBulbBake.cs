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
    [Weight(300)]                                          
    public partial class CamasBulbBakeItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Camas Bulb Bake"; } }
        public override string Description                      { get { return "A spread of evenly baked camas bulbs; soft in the middle, golden brown on the outside."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 5, Protein = 7, Vitamins = 4};
        public override float Calories                          { get { return 400; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 1)]    
    public partial class CamasBulbBakeRecipe : Recipe
    {
        public CamasBulbBakeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasBulbBakeItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(BasicBakingEfficiencySkill), 15, BasicBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasBulbBakeRecipe), Item.Get<CamasBulbBakeItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize("Camas Bulb Bake", typeof(CamasBulbBakeRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
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
    [Weight(800)]                                          
    public partial class MeatStockItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Meat Stock"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A meaty stock made from the flesh of animals."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 7, Protein = 6, Vitamins = 5};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MeatStockRecipe : Recipe
    {
        public MeatStockRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MeatStockItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MeatStockRecipe), Item.Get<MeatStockItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Meat Stock"), typeof(MeatStockRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}
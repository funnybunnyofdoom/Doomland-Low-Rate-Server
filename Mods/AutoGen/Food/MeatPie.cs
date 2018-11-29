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
    [Weight(600)]                                          
    public partial class MeatPieItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Meat Pie"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Much like a huckleberry pie, but filled to the brim with succulent meat."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 10, Protein = 10, Vitamins = 4};
        public override float Calories                          { get { return 1500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 4)]    
    public partial class MeatPieRecipe : Recipe
    {
        public MeatPieRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MeatPieItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PreparedMeatItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FlourItem>(typeof(BasicBakingEfficiencySkill), 10, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MeatPieRecipe), Item.Get<MeatPieItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Meat Pie"), typeof(MeatPieRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
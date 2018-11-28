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
    public partial class CharredTomatoItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Charred Tomato"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("The blackened char on this tomato would contrast well with the red skin if there was any unburt surface left."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 0, Protein = 1, Vitamins = 4};
        public override float Calories                          { get { return 510; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    public partial class CharredTomatoRecipe : Recipe
    {
        public CharredTomatoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredTomatoItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TomatoItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy)    
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredTomatoRecipe), Item.Get<CharredTomatoItem>().UILink(), 3, typeof(CampfireCreationsSpeedSkill));    
            this.Initialize(Localizer.DoStr("Charred Tomato"), typeof(CharredTomatoRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
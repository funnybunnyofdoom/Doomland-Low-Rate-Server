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
    public partial class CharredMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Meat"; } }
        public override string FriendlyNamePlural               { get { return "Charred Meat"; } } 
        public override string Description                      { get { return "The blackened surface of this unrecognizable meat is 'golden brown'."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 10, Protein = 10, Vitamins = 0};
        public override float Calories                          { get { return 550; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    public partial class CharredMeatRecipe : Recipe
    {
        public CharredMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredMeatItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy)   
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredMeatRecipe), Item.Get<CharredMeatItem>().UILink(), 3, typeof(CampfireCreationsSpeedSkill)); 
            this.Initialize("Charred Meat", typeof(CharredMeatRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
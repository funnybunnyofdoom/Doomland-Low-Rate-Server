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
    public partial class CharredCornItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Corn"; } }
        public override string FriendlyNamePlural               { get { return "Charred Corn"; } } 
        public override string Description                      { get { return "This piece of corn needs a good slathering of butter to curb that burnt taste."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 0, Protein = 1, Vitamins = 4};
        public override float Calories                          { get { return 530; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    public partial class CharredCornRecipe : Recipe
    {
        public CharredCornRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredCornItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy)    
            };
            this.CraftMinutes = new ConstantValue(2);     
            this.Initialize("Charred Corn", typeof(CharredCornRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
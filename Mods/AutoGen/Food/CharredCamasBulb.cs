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
    public partial class CharredCamasBulbItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Camas Bulb"; } }
        public override string Description                      { get { return "A fibrous and sweet treat much like a sweet potato, though slightly blackened over the heat of a campfire."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 7, Protein = 3, Vitamins = 1};
        public override float Calories                          { get { return 510; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    public partial class CharredCamasBulbRecipe : Recipe
    {
        public CharredCamasBulbRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredCamasBulbItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy)   
            };
            this.CraftMinutes = new ConstantValue(2);     
            this.Initialize("Charred Camas Bulb", typeof(CharredCamasBulbRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
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
    public partial class InfusedOilItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Infused Oil"; } }
        public override string Description                      { get { return "Oil infused with flavor to enhance it."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 12, Protein = 0, Vitamins = 3};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class InfusedOilRecipe : Recipe
    {
        public InfusedOilRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<InfusedOilItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<OilItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberryExtractItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(InfusedOilRecipe), Item.Get<InfusedOilItem>().UILink(), 5, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Infused Oil", typeof(InfusedOilRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
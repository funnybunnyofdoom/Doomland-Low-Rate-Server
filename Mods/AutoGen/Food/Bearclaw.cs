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
    public partial class BearclawItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Bearclaw"; } }
        public override string Description                      { get { return "A sweet pastry with seperated sections that look a bit like a claw."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 21, Protein = 6, Vitamins = 7};
        public override float Calories                          { get { return 650; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(LeavenedBakingSkill), 2)]    
    public partial class BearclawRecipe : Recipe
    {
        public BearclawRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BearclawItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(LeavenedBakingEfficiencySkill), 8, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SugarItem>(typeof(LeavenedBakingEfficiencySkill), 8, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(LeavenedBakingEfficiencySkill), 3, LeavenedBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BearclawRecipe), Item.Get<BearclawItem>().UILink(), 8, typeof(LeavenedBakingSpeedSkill)); 
            this.Initialize("Bearclaw", typeof(BearclawRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
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
    public partial class BakedRoastItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Baked Roast"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A trussed roast baked to perfection."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 8, Protein = 13, Vitamins = 7};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 3)]    
    public partial class BakedRoastRecipe : Recipe
    {
        public BakedRoastRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BakedRoastItem>(),
               
               new CraftingElement<TallowItem>(1) 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawRoastItem>(typeof(BasicBakingEfficiencySkill), 3, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FiddleheadsItem>(typeof(BasicBakingEfficiencySkill), 10, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CamasBulbItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedRoastRecipe), Item.Get<BakedRoastItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Baked Roast"), typeof(BakedRoastRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
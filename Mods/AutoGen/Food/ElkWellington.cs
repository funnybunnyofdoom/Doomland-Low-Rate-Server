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
    public partial class ElkWellingtonItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Elk Wellington"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A prime cut of meat surrounded by pastry."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 12, Protein = 20, Vitamins = 8};
        public override float Calories                          { get { return 1400; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(LeavenedBakingSkill), 4)]    
    public partial class ElkWellingtonRecipe : Recipe
    {
        public ElkWellingtonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElkWellingtonItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(LeavenedBakingEfficiencySkill), 20, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PrimeCutItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElkWellingtonRecipe), Item.Get<ElkWellingtonItem>().UILink(), 8, typeof(LeavenedBakingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Elk Wellington"), typeof(ElkWellingtonRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
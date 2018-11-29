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
    public partial class SimmeredMeatItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Simmered Meat"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Meat cooked in meat juices keeps the meat juicy."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 8, Protein = 12, Vitamins = 4};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 3)]    
    public partial class SimmeredMeatRecipe : Recipe
    {
        public SimmeredMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SimmeredMeatItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PreparedMeatItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<MeatStockItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SimmeredMeatRecipe), Item.Get<SimmeredMeatItem>().UILink(), 10, typeof(HomeCookingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Simmered Meat"), typeof(SimmeredMeatRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}
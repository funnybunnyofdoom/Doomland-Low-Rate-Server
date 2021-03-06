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
    [Weight(200)]                                          
    public partial class CrispyBaconItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Crispy Bacon"); } }
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Crispy Bacon"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Give me all the bacon and eggs you have."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 14, Protein = 8, Vitamins = 0};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 4)]    
    public partial class CrispyBaconRecipe : Recipe
    {
        public CrispyBaconRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CrispyBaconItem>(),
               
               new CraftingElement<TallowItem>(4) 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawBaconItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrispyBaconRecipe), Item.Get<CrispyBaconItem>().UILink(), 10, typeof(HomeCookingSpeedSkill)); 
            this.Initialize(Localizer.DoStr("Crispy Bacon"), typeof(CrispyBaconRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}
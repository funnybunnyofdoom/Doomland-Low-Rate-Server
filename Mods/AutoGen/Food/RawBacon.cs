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
    [Weight(50)]                                          
    public partial class RawBaconItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Raw Bacon"; } }
        public override string FriendlyNamePlural               { get { return "Raw Bacon"; } } 
        public override string Description                      { get { return "A fatty cut of meat that happens to be inexplicably tastier than other cuts."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 9, Protein = 3, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 3)]    
    public partial class RawBaconRecipe : Recipe
    {
        public RawBaconRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawBaconItem>(),
               
               new CraftingElement<ScrapMeatItem>(5) 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MeatPrepEfficiencySkill), 20, MeatPrepEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RawBaconRecipe), Item.Get<RawBaconItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Raw Bacon", typeof(RawBaconRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
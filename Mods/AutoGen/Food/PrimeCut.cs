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
    public partial class PrimeCutItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Prime Cut"; } }
        public override string Description                      { get { return "A perfectly marbled piece of meat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 4, Protein = 9, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 4)]    
    public partial class PrimeCutRecipe : Recipe
    {
        public PrimeCutRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PrimeCutItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MeatPrepEfficiencySkill), 40, MeatPrepEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PrimeCutRecipe), Item.Get<PrimeCutItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Prime Cut", typeof(PrimeCutRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
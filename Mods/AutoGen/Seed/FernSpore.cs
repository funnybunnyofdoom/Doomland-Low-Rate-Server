namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Weight(50)]  
    public partial class FernSporeItem : SeedItem
    {
        static FernSporeItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Fern Spore"; } }
        public override string Description  { get { return "Plant to grow ferns."; } }
        public override string SpeciesName  { get { return "Fern"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class FernSporePackItem : SeedPackItem
    {
        static FernSporePackItem() { }

        public override string FriendlyName { get { return "Fern Spore Pack"; } }
        public override string Description  { get { return "Plant to grow ferns."; } }
        public override string SpeciesName  { get { return "Fern"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 1)]    
    public class FernSporeRecipe : Recipe
    {
        public FernSporeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FernSporeItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiddleheadsItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy)   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FernSporeRecipe), Item.Get<FernSporeItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FernSporeItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Fern Spore", typeof(FernSporeRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
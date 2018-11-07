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
    public partial class FireweedSeedItem : SeedItem
    {
        static FireweedSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Fireweed Seed"; } }
        public override string Description  { get { return "Plant to grow fireweed."; } }
        public override string SpeciesName  { get { return "Fireweed"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class FireweedSeedPackItem : SeedPackItem
    {
        static FireweedSeedPackItem() { }

        public override string FriendlyName { get { return "Fireweed Seed Pack"; } }
        public override string Description  { get { return "Plant to grow fireweed."; } }
        public override string SpeciesName  { get { return "Fireweed"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 3)]    
    public class FireweedSeedRecipe : Recipe
    {
        public FireweedSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FireweedSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FireweedShootsItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy)   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FireweedSeedRecipe), Item.Get<FireweedSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FireweedSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Fireweed Seed", typeof(FireweedSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
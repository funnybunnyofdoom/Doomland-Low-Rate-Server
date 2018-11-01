namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
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
    public partial class CedarSeedItem : SeedItem
    {
        static CedarSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Cedar Cone"; } }
        public override string Description  { get { return "Plant to grow a cedar sapling."; } }
        public override string SpeciesName  { get { return "Cedar"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class CedarSeedPackItem : SeedPackItem
    {
        static CedarSeedPackItem() { }

        public override string FriendlyName { get { return "Cedar Seed Pack"; } }
        public override string Description  { get { return "Plant to grow a cedar sapling."; } }
        public override string SpeciesName  { get { return "Cedar"; } }
    }
	
	[RequiresSkill(typeof(SeedProductionSkill), 4)]    
    public class CedarSeedRecipe : Recipe
    {
        public CedarSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CedarSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(SeedProductionEfficiencySkill), 150, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CedarSeedRecipe), Item.Get<CedarSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CedarSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Cedar Cone", typeof(CedarSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
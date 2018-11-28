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
    public partial class CornSeedItem : SeedItem
    {
        static CornSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Corn Seed"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow corn."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Corn"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class CornSeedPackItem : SeedPackItem
    {
        static CornSeedPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Corn Seed Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow corn."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Corn"); } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 4)]    
    public class CornSeedRecipe : Recipe
    {
        public CornSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CornSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy)   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CornSeedRecipe), Item.Get<CornSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CornSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize(Localizer.DoStr("Corn Seed"), typeof(CornSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
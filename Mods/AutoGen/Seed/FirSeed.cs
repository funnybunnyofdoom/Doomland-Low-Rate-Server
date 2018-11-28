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
    public partial class FirSeedItem : SeedItem
    {
        static FirSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Fir Seed"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a fir tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fir"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class FirSeedPackItem : SeedPackItem
    {
        static FirSeedPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Fir Seed Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a fir tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fir"); } }
    }
	
	[RequiresSkill(typeof(SeedProductionSkill), 4)]    
    public class FirSeedRecipe : Recipe
    {
        public FirSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FirSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(SeedProductionEfficiencySkill), 150, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FirSeedRecipe), Item.Get<FirSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FirSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize(Localizer.DoStr("Fir Cone"), typeof(FirSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

}
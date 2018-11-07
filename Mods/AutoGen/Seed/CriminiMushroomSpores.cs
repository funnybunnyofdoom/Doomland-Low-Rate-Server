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
    public partial class CriminiMushroomSporesItem : SeedItem
    {
        static CriminiMushroomSporesItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Crimini Mushroom Spores"; } }
        public override string Description  { get { return "Plant to grow crimini mushrooms."; } }
        public override string SpeciesName  { get { return "CriminiMushroom"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class CriminiMushroomSporesPackItem : SeedPackItem
    {
        static CriminiMushroomSporesPackItem() { }

        public override string FriendlyName { get { return "Crimini Mushroom Spores Pack"; } }
        public override string Description  { get { return "Plant to grow crimini mushrooms."; } }
        public override string SpeciesName  { get { return "CriminiMushroom"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public class CriminiMushroomSporesRecipe : Recipe
    {
        public CriminiMushroomSporesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CriminiMushroomSporesItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CriminiMushroomsItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy)   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CriminiMushroomSporesRecipe), Item.Get<CriminiMushroomSporesItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CriminiMushroomSporesItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Crimini Mushroom Spores", typeof(CriminiMushroomSporesRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
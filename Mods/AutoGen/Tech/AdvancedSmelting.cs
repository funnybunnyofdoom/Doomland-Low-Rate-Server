namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(SmithSkill), 0)]    
    public partial class AdvancedSmeltingSkill : Skill
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Advanced Smelting"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class AdvancedSmeltingSkillBook : SkillBook<AdvancedSmeltingSkill, AdvancedSmeltingSkillScroll>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Advanced Smelting Skill Book"); } }
    }

    [Serialized]
    public partial class AdvancedSmeltingSkillScroll : NewSkillScroll<AdvancedSmeltingSkill, AdvancedSmeltingSkillBook>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Advanced Smelting Skill Scroll"); } }
    }

    [RequiresSkill(typeof(SmeltingSkill), 0)] 
    public partial class AdvancedSmeltingSkillBookRecipe : Recipe
    {
        public AdvancedSmeltingSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AdvancedSmeltingSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CoalItem>(typeof(ResearchEfficiencySkill), 200, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BrickItem>(typeof(ResearchEfficiencySkill), 100, ResearchEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<PaperItem>(typeof(ResearchEfficiencySkill), 20, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(30);

            this.Initialize(Localizer.DoStr("Advanced Smelting Skill Book"), typeof(AdvancedSmeltingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

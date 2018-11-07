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
    [RequiresSkill(typeof(TailorSkill), 0)]    
    public partial class TailoringSkill : Skill
    {
        public override string FriendlyName { get { return "Tailoring"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class TailoringSkillBook : SkillBook<TailoringSkill, TailoringSkillScroll>
    {
        public override string FriendlyName { get { return "Tailoring Skill Book"; } }
    }

    [Serialized]
    public partial class TailoringSkillScroll : NewSkillScroll<TailoringSkill, TailoringSkillBook>
    {
        public override string FriendlyName { get { return "Tailoring Skill Scroll"; } }
    }

    [RequiresSkill(typeof(GatheringSkill), 0)] 
    public partial class TailoringSkillBookRecipe : Recipe
    {
        public TailoringSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TailoringSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ResearchEfficiencySkill), 40, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FurPeltItem>(typeof(ResearchEfficiencySkill), 5, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LeatherHideItem>(typeof(ResearchEfficiencySkill), 5, ResearchEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<PaperItem>(typeof(ResearchEfficiencySkill), 25, ResearchEfficiencySkill.MultiplicativeStrategy)	 
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Tailoring Skill Book", typeof(TailoringSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

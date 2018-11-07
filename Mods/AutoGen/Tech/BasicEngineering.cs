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
    [RequiresSkill(typeof(EngineerSkill), 0)]    
    public partial class BasicEngineeringSkill : Skill
    {
        public override string FriendlyName { get { return "Basic Engineering"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class BasicEngineeringSkillBook : SkillBook<BasicEngineeringSkill, BasicEngineeringSkillScroll>
    {
        public override string FriendlyName { get { return "Basic Engineering Skill Book"; } }
    }

    [Serialized]
    public partial class BasicEngineeringSkillScroll : NewSkillScroll<BasicEngineeringSkill, BasicEngineeringSkillBook>
    {
        public override string FriendlyName { get { return "Basic Engineering Skill Scroll"; } }
    }

    [RequiresSkill(typeof(HewingSkill), 0)] 
    public partial class BasicEngineeringSkillBookRecipe : Recipe
    {
        public BasicEngineeringSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BasicEngineeringSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(ResearchEfficiencySkill), 10, ResearchEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<PaperItem>(typeof(ResearchEfficiencySkill), 25, ResearchEfficiencySkill.MultiplicativeStrategy)	 
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Basic Engineering Skill Book", typeof(BasicEngineeringSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

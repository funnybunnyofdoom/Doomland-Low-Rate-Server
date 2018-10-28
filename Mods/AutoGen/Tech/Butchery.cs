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
    [RequiresSkill(typeof(HunterSkill), 0)]    
    public partial class ButcherySkill : Skill
    {
        public override string FriendlyName { get { return "Butchery"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class ButcherySkillBook : SkillBook<ButcherySkill, ButcherySkillScroll>
    {
        public override string FriendlyName { get { return "Butchery Skill Book"; } }
    }

    [Serialized]
    public partial class ButcherySkillScroll : SkillScroll<ButcherySkill, ButcherySkillBook>
    {
        public override string FriendlyName { get { return "Butchery Skill Scroll"; } }
    }

    [RequiresSkill(typeof(HuntingSkill), 0)] 
    public partial class ButcherySkillBookRecipe : Recipe
    {
        public ButcherySkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ButcherySkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HareCarcassItem>(typeof(ResearchEfficiencySkill), 3, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ElkCarcassItem>(typeof(ResearchEfficiencySkill), 3, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BisonCarcassItem>(typeof(ResearchEfficiencySkill), 1, ResearchEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Butchery Skill Book", typeof(ButcherySkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

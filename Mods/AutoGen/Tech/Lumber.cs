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
    [RequiresSkill(typeof(CarpenterSkill), 0)]    
    public partial class LumberSkill : Skill
    {
        public override string FriendlyName { get { return "Lumber"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public override int RequiredPoint { get { return 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class LumberSkillBook : SkillBook<LumberSkill, LumberSkillScroll>
    {
        public override string FriendlyName { get { return "Lumber Skill Book"; } }
    }

    [Serialized]
    public partial class LumberSkillScroll : NewSkillScroll<LumberSkill, LumberSkillBook>
    {
        public override string FriendlyName { get { return "Lumber Skill Scroll"; } }
    }

    [RequiresSkill(typeof(HewingSkill), 0)] 
    public partial class LumberSkillBookRecipe : Recipe
    {
        public LumberSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LumberSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(ResearchEfficiencySkill), 20, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HewnLogItem>(typeof(ResearchEfficiencySkill), 40, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ResearchEfficiencySkill), 20, ResearchEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = new ConstantValue(15);

            this.Initialize("Lumber Skill Book", typeof(LumberSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

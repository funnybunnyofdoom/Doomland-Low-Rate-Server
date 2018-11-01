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
    public partial class OilDrillingSkill : Skill
    {
        public override string FriendlyName { get { return "Oil Drilling"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class OilDrillingSkillBook : SkillBook<OilDrillingSkill, OilDrillingSkillScroll>
    {
        public override string FriendlyName { get { return "Oil Drilling Skill Book"; } }
    }

    [Serialized]
    public partial class OilDrillingSkillScroll : NewSkillScroll<OilDrillingSkill, OilDrillingSkillBook>
    {
        public override string FriendlyName { get { return "Oil Drilling Skill Scroll"; } }
    }

    [RequiresSkill(typeof(MechanicsSkill), 0)] 
    public partial class OilDrillingSkillBookRecipe : Recipe
    {
        public OilDrillingSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilDrillingSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ReinforcedConcreteItem>(typeof(ResearchEfficiencySkill), 50, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CombustionEngineItem>(typeof(ResearchEfficiencySkill), 4, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LumberItem>(typeof(ResearchEfficiencySkill), 80, ResearchEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = new ConstantValue(30);

            this.Initialize("Oil Drilling Skill Book", typeof(OilDrillingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

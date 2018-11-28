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
    public partial class MasonSkill : Skill
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Mason"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        public override string Title { get { return Localizer.DoStr("Mason"); } }  
        public override int RequiredPoint { get { return 0; } }
        public override int MaxLevel { get { return 1; } }
    }

}

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    [Serialized]
    [Weight(0)]
    [Category("Hidden")]
    public partial class FitTorsoItem :
        ClothingItem
    {
        public override string FriendlyName { get { return "Fit Torso"; } }
        public override string Description  { get { return "Torso"; } }
        public override string Slot         { get { return ClothingSlot.Torso; } } 
    }
}
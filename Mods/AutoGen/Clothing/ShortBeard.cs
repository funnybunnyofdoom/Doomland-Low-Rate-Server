namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
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
    [Category("Hidden")]  
    [Weight(100)]      
    public partial class ShortBeardItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Short Beard"; } }
        public override string Description      { get { return ""; } }
        public override string Slot             { get { return ClothingSlot.FacialHair; } }             
        public override bool Starter            { get { return true ; } }                       

    }

}
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;



    [Serialized]
    [Weight(0)]      
    [Currency]                                              
    public partial class ScytheItem :
    ToolItem                        
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Scythe"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Nothing says harvest time (or death) like a scythe."); } }

    }

}
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
    [Weight(100)]      
    [Fuel(10000000)][Tag("Fuel")]          
    [Category("Hidden")]    
    [Currency]                                              
    public partial class StrangeFuelItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Strange Fuel"; } } 
        public override string Description { get { return "CHEEEAAAAATER"; } }

    }

}
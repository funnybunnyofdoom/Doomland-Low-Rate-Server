namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Crop]  
    [Weight(50)]  
    public partial class SugarcaneItem : SeedItem
    {
        static SugarcaneItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 1, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Sugarcane"; } }
        public override string Description  { get { return "How did you even get this?"; } }
        public override string SpeciesName  { get { return "Wheat"; } }

        public override float Calories { get { return 1; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class SugarcanePackItem : SeedPackItem
    {
        static SugarcanePackItem() { }

        public override string FriendlyName { get { return "Sugarcane Pack"; } }
        public override string Description  { get { return "How did you even get this?"; } }
        public override string SpeciesName  { get { return "Wheat"; } }
    }

}
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
    [Weight(50)]  
    public partial class BirchSeedItem : SeedItem
    {
        static BirchSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Birch Seed"; } }
        public override string Description  { get { return "Plant to grow into a birch sapling."; } }
        public override string SpeciesName  { get { return "Birch"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class BirchSeedPackItem : SeedPackItem
    {
        static BirchSeedPackItem() { }

        public override string FriendlyName { get { return "Birch Seed Pack"; } }
        public override string Description  { get { return "Plant to grow into a birch sapling."; } }
        public override string SpeciesName  { get { return "Birch"; } }
    }

}
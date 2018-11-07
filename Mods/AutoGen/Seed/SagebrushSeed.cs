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
    public partial class SagebrushSeedItem : SeedItem
    {
        static SagebrushSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Sagebrush Seed"; } }
        public override string Description  { get { return "Plant to grow sagebrush."; } }
        public override string SpeciesName  { get { return "Sagebrush"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class SagebrushSeedPackItem : SeedPackItem
    {
        static SagebrushSeedPackItem() { }

        public override string FriendlyName { get { return "Sagebrush Seed Pack"; } }
        public override string Description  { get { return "Plant to grow sagebrush."; } }
        public override string SpeciesName  { get { return "Sagebrush"; } }
    }

}
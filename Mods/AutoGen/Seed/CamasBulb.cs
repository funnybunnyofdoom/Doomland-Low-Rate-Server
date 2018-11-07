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
    [Yield(typeof(CamasBulbItem), typeof(GrasslandGathererSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Crop]  
    [Weight(50)]  
    public partial class CamasBulbItem : SeedItem
    {
        static CamasBulbItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 1, Fat = 5, Protein = 2, Vitamins = 0 };

        public override string FriendlyName { get { return "Camas Bulb"; } }
        public override string Description  { get { return "Plant to grow a camas plant."; } }
        public override string SpeciesName  { get { return "Camas"; } }

        public override float Calories { get { return 120; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class CamasBulbPackItem : SeedPackItem
    {
        static CamasBulbPackItem() { }

        public override string FriendlyName { get { return "Camas Bulb Pack"; } }
        public override string Description  { get { return "Plant to grow a camas plant."; } }
        public override string SpeciesName  { get { return "Camas"; } }
    }

}
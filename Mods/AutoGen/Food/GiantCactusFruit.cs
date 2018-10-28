namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;

    [Serialized]
    [Weight(10)]                                          
    [Yield(typeof(GiantCactusFruitItem), typeof(DesertDrifterSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})][Tag("Crop")]      
    [Crop]                                                      
    public partial class GiantCactusFruitItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Giant Cactus Fruit"; } }
        public override string Description                      { get { return "A bulbous fruit that used to top Saguaro cacti."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 3, Protein = 0, Vitamins = 5};
        public override float Calories                          { get { return 300; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}
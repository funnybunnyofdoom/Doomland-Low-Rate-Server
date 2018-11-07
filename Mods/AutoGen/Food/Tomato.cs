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
    [Weight(8)]                                          
    [Yield(typeof(TomatoItem), typeof(GrasslandGathererSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})][Tag("Crop")]      
    [Crop]                                                      
    public partial class TomatoItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Tomato"; } }
        public override string Description                      { get { return "Intelligence is knowing this is a fruit; wisdom is not putting it in a fruit salad."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 0, Protein = 1, Vitamins = 3};
        public override float Calories                          { get { return 240; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}
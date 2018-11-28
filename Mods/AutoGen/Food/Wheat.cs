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
    [Yield(typeof(WheatItem), typeof(GrasslandGathererSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})][Tag("Crop")]      
    [Crop]                                                      
    public partial class WheatItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Wheat"); } }
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Wheat"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A common grain that is significantly more useful processed."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 0, Protein = 2, Vitamins = 0};
        public override float Calories                          { get { return 130; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}
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
    [Weight(100)]      
    public partial class SquareBeltItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Square Belt"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Belt with a square buckle."); } }
        public override string Slot             { get { return ClothingSlot.Belt; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 0)]
    public class SquareBeltRecipe : Recipe
    {
        public SquareBeltRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SquareBeltItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 2, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Square Belt"), typeof(SquareBeltRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
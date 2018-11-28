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
    public partial class TallBootsItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Tall Boots"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Knee-high boots are boots that rise to the knee, or slightly thereunder. They are generally tighter around the leg shaft and ankle than at the top."); } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class TallBootsRecipe : Recipe
    {
        public TallBootsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallBootsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 2, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FurPeltItem>(typeof(ClothesmakingEfficiencySkill), 5, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Tall Boots"), typeof(TallBootsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
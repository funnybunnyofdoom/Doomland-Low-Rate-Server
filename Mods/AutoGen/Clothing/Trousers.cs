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
    public partial class TrousersItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Trousers"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Sturdy pair of slim-fit pants. Trousers are an item of clothing worn from the waist to the ankles, covering both legs separately (rather than with cloth extending across both legs as in robes, skirts, and dresses)."); } }
        public override string Slot             { get { return ClothingSlot.Pants; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class TrousersRecipe : Recipe
    {
        public TrousersRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TrousersItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 2, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FurPeltItem>(typeof(ClothesmakingEfficiencySkill), 1, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 20, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize(Localizer.DoStr("Trousers"), typeof(TrousersRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
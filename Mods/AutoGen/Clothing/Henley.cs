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
    public partial class HenleyItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Henley"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A Henley shirt is a collarless pullover shirt, characterized by a placket beneath the round neckline, about 8 to 13 cm long and usually having 2?5 buttons. It essentially resembles a collarless polo shirt."); } }
        public override string Slot             { get { return ClothingSlot.Shirt; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class HenleyRecipe : Recipe
    {
        public HenleyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HenleyItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 1, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 25, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize(Localizer.DoStr("Henley"), typeof(HenleyRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
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
    public partial class FabulousPantsItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Fabulous Pants"; } }
        public override string Description      { get { return "Irresistibly fabulous pants."; } }
        public override string Slot             { get { return ClothingSlot.Pants; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class FabulousPantsRecipe : Recipe
    {
        public FabulousPantsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FabulousPantsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 120, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize("Fabulous Pants", typeof(FabulousPantsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
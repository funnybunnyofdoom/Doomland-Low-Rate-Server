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
    public partial class CaprisItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Capris"; } }
        public override string Description      { get { return "Capri pants (also known as three quarter pants, capris, crop pants, pedal pushers, clam-diggers, flood pants, jams, highwaters, culottes, or toreador pants) are pants that are longer than shorts but are not as long as trousers."; } }
        public override string Slot             { get { return ClothingSlot.Pants; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class CaprisRecipe : Recipe
    {
        public CaprisRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CaprisItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 60, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize("Capris", typeof(CaprisRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
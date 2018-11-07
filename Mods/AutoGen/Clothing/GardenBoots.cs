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
    public partial class GardenBootsItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Garden Boots"; } }
        public override string Description      { get { return ""; } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class GardenBootsRecipe : Recipe
    {
        public GardenBootsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GardenBootsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 60, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize("Garden Boots", typeof(GardenBootsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
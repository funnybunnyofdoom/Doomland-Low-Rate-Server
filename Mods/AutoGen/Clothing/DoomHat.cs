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
    public partial class DoomHatItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Doom Hat"; } }
        public override string Description      { get { return "Deadly looking sombrero that doesn't fit anyone. You feel scurred to wear it."; } }
        public override string Slot             { get { return ClothingSlot.Head; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class DoomHatRecipe : Recipe
    {
        public DoomHatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoomHatItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(ClothesmakingEfficiencySkill), 80, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize("Doom Hat", typeof(DoomHatRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
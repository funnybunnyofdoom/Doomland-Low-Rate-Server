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
    public partial class BearpackItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Bearpack"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Lets you carry as much as a bear! Not really, but it does help you carry more."); } }
        public override string Slot             { get { return ClothingSlot.Back; } }             
        public override bool Starter            { get { return false ; } }                       

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
    {
                { UserStatType.MaxCarryWeight, 15000f }
    };
public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 4)]
    public class BearpackRecipe : Recipe
    {
        public BearpackRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BearpackItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CelluloseFiberItem>(typeof(ClothesmakingEfficiencySkill), 40, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothesmakingEfficiencySkill), 30, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FurPeltItem>(typeof(ClothesmakingEfficiencySkill), 50, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Bearpack"), typeof(BearpackRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
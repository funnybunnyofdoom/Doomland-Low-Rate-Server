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
    public partial class RunningShoesItem :
        ClothingItem        
    {

        public override string FriendlyName     { get { return "Running Shoes"; } }
        public override string Description      { get { return "FASTER SHOES???"; } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return false ; } }                       

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
    {
                { UserStatType.MovementSpeed, 0.5f }
    };
public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class RunningShoesRecipe : Recipe
    {
        public RunningShoesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RunningShoesItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 10, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothesmakingEfficiencySkill), 5, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize("Running Shoes", typeof(RunningShoesRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
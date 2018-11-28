namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(MetalworkingSkill), 3)]   
    [RepairRequiresSkill(typeof(MetalworkingSkill), 1)] 
    public partial class IronHoeRecipe : Recipe
    {
        public IronHoeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<IronHoeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(MetalworkingEfficiencySkill), 10, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronHoeRecipe), Item.Get<IronHoeItem>().UILink(), 0.5f, typeof(MetalworkingSpeedSkill));    
            this.Initialize(Localizer.DoStr("Iron Hoe"), typeof(IronHoeRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class IronHoeItem : HoeItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Iron Hoe"); } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(17, typeof(HoeEfficiencySkill), typeof(IronHoeItem), new IronHoeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, MetalworkingSkill.MultiplicativeStrategy, typeof(MetalworkingSkill), Localizer.DoStr("repair cost"));        
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 300f; } }
        
        public override Item RepairItem         {get{ return Item.Get<IronIngotItem>(); } }
        public override int FullRepairAmount    {get{ return 8; } }
    }
}
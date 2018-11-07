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

    [RequiresSkill(typeof(MetalworkingSkill), 1)]   
    [RepairRequiresSkill(typeof(MetalworkingSkill), 1)] 
    public partial class IronAxeRecipe : Recipe
    {
        public IronAxeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<IronAxeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(MetalworkingEfficiencySkill), 10, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronAxeRecipe), Item.Get<IronAxeItem>().UILink(), 0.5f, typeof(MetalworkingSpeedSkill));    
            this.Initialize("Iron Axe", typeof(IronAxeRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class IronAxeItem : AxeItem
    {

        public override string FriendlyName { get { return "Iron Axe"; } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(17, typeof(LoggingEfficiencySkill), typeof(IronAxeItem), new IronAxeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }
        private static IDynamicValue damage = CreateDamageValue(1.5f, typeof(LoggingDamageSkill), typeof(IronAxeItem), new IronAxeItem().UILink());
        public override IDynamicValue Damage { get { return damage; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, MetalworkingSkill.MultiplicativeStrategy, typeof(MetalworkingSkill), Localizer.DoStr("repair cost"));        
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 750f; } }
        
        public override Item RepairItem         {get{ return Item.Get<IronIngotItem>(); } }
        public override int FullRepairAmount    {get{ return 8; } }
    }
}
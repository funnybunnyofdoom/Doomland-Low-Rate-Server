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

    public partial class WoodenShovelRecipe : Recipe
    {
        public WoodenShovelRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<WoodenShovelItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 10, BasicCraftingEfficiencySkill.MultiplicativeStrategy),    
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenShovelRecipe), this.UILink(), 0.5f, typeof(BasicCraftingSpeedSkill));
            this.Initialize(Localizer.DoStr("Wooden Shovel"), typeof(WoodenShovelRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class WoodenShovelItem : ShovelItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Shovel"); } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(20, typeof(ShovelEfficiencySkill), typeof(WoodenShovelItem), new WoodenShovelItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static IDynamicValue skilledRepairCost = new SkillModifiedValue(5, BasicCraftingEfficiencySkill.MultiplicativeStrategy, typeof(BasicCraftingEfficiencySkill), Localizer.DoStr("repair cost"));
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 100f; } }
        
        public override Item RepairItem         {get{ return Item.Get<LogItem>(); } }
        public override int FullRepairAmount    {get{ return 5; } }
    }
}
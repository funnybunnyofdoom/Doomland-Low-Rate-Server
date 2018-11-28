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

    public partial class StoneAxeRecipe : Recipe
    {
        public StoneAxeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<StoneAxeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 3, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(BasicCraftingEfficiencySkill), 10, BasicCraftingEfficiencySkill.MultiplicativeStrategy),   
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneAxeRecipe), this.UILink(), 0.5f, typeof(BasicCraftingSpeedSkill));
            this.Initialize(Localizer.DoStr("Stone Axe"), typeof(StoneAxeRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class StoneAxeItem : AxeItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Stone Axe"); } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(20, typeof(LoggingEfficiencySkill), typeof(StoneAxeItem), new StoneAxeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }
        private static IDynamicValue damage = CreateDamageValue(1, typeof(LoggingDamageSkill), typeof(StoneAxeItem), new StoneAxeItem().UILink());
        public override IDynamicValue Damage { get { return damage; } }

        private static IDynamicValue skilledRepairCost = new SkillModifiedValue(5, BasicCraftingEfficiencySkill.MultiplicativeStrategy, typeof(BasicCraftingEfficiencySkill), Localizer.DoStr("repair cost")); 
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 250f; } }
        
        public override Item RepairItem         {get{ return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount    {get{ return 5; } }
    }
}
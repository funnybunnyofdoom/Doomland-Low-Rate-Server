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

    public partial class StonePickaxeRecipe : Recipe
    {
        public StonePickaxeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<StonePickaxeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 3, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(BasicCraftingEfficiencySkill), 10, BasicCraftingEfficiencySkill.MultiplicativeStrategy)    
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StonePickaxeRecipe), this.UILink(), 0.5f, typeof(BasicCraftingSpeedSkill));
            this.Initialize("Stone Pickaxe", typeof(StonePickaxeRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class StonePickaxeItem : PickaxeItem
    {

        public override string FriendlyName { get { return "Stone Pickaxe"; } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(20, typeof(MiningEfficiencySkill), typeof(StonePickaxeItem), new StonePickaxeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(5);  
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 100f; } }
        
        public override Item RepairItem         {get{ return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount    {get{ return 5; } }
    }
}
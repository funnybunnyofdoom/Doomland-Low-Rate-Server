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

    public partial class StoneHammerRecipe : Recipe
    {
        public StoneHammerRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<StoneHammerItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(3),
                new CraftingElement<StoneItem>(10)    
            };
            this.CraftMinutes = new ConstantValue(0.5f);
            this.Initialize("Stone Hammer", typeof(StoneHammerRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class StoneHammerItem : HammerItem
    {

        public override string FriendlyName { get { return "Stone Hammer"; } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(20, typeof(CalorieEfficiencySkill), typeof(StoneHammerItem), new StoneHammerItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(5);  
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 100f; } }
        
        public override Item RepairItem         {get{ return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount    {get{ return 5; } }
    }
}
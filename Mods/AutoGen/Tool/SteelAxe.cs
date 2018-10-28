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

    [RequiresSkill(typeof(SteelworkingSkill), 1)]   
    [RepairRequiresSkill(typeof(SteelworkingSkill), 1)] 
    public partial class SteelAxeRecipe : Recipe
    {
        public SteelAxeRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<SteelAxeItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoardItem>(typeof(SteelworkingEfficiencySkill), 10, SteelworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelAxeRecipe), Item.Get<SteelAxeItem>().UILink(), 0.5f, typeof(SteelworkingSpeedSkill));    
            this.Initialize("Steel Axe", typeof(SteelAxeRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class SteelAxeItem : AxeItem
    {

        public override string FriendlyName { get { return "Steel Axe"; } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(15, typeof(LoggingEfficiencySkill), typeof(SteelAxeItem), new SteelAxeItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }
        private static IDynamicValue damage = CreateDamageValue(2, typeof(LoggingDamageSkill), typeof(SteelAxeItem), new SteelAxeItem().UILink());
        public override IDynamicValue Damage { get { return damage; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, SteelworkingSkill.MultiplicativeStrategy, typeof(SteelworkingSkill), Localizer.DoStr("repair cost"));        
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 1250f; } }
        
        public override Item RepairItem         {get{ return Item.Get<SteelItem>(); } }
        public override int FullRepairAmount    {get{ return 8; } }
    }
}
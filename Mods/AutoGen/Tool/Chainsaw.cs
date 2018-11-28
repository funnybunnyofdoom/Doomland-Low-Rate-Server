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
    [RepairRequiresSkill(typeof(SteelworkingSkill), 3)] 
    public partial class ChainsawRecipe : Recipe
    {
        public ChainsawRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<ChainsawItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberglassItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 30, SteelworkingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChainsawRecipe), Item.Get<ChainsawItem>().UILink(), 0.5f, typeof(SteelworkingSpeedSkill));    
            this.Initialize(Localizer.DoStr("Chainsaw"), typeof(ChainsawRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class ChainsawItem : AxeItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Chainsaw"); } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(10, typeof(LoggingEfficiencySkill), typeof(ChainsawItem), new ChainsawItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }
        private static IDynamicValue damage = CreateDamageValue(10, typeof(LoggingDamageSkill), typeof(ChainsawItem), new ChainsawItem().UILink());
        public override IDynamicValue Damage { get { return damage; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(15, SteelworkingSkill.MultiplicativeStrategy, typeof(SteelworkingSkill), Localizer.DoStr("repair cost"));        
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 2500f; } }
        
        public override Item RepairItem         {get{ return Item.Get<SteelItem>(); } }
        public override int FullRepairAmount    {get{ return 15; } }
    }
}
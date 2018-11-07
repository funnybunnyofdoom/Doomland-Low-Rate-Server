namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(AlloySmeltingSkill), 2)]   
    public partial class SteelRecipe : Recipe
    {
        public SteelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CoalItem>(2), 
                new CraftingElement<IronIngotItem>(typeof(AlloySmeltingEfficiencySkill), 5, AlloySmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelRecipe), Item.Get<SteelItem>().UILink(), 3, typeof(AlloySmeltingSpeedSkill));    
            this.Initialize("Steel", typeof(SteelRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }


    [Serialized]
    [Weight(2500)]      
    [Currency]                                              
    public partial class SteelItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Steel"; } } 
        public override string Description { get { return "A strong alloy of iron and other elements."; } }

    }

}
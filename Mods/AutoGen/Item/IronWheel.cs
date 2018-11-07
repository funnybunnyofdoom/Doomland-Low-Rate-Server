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

    [RequiresSkill(typeof(PrimitiveMechanicsSkill), 1)]   
    public partial class IronWheelRecipe : Recipe
    {
        public IronWheelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronWheelItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(PrimitiveMechanicsEfficiencySkill), 20, PrimitiveMechanicsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronWheelRecipe), Item.Get<IronWheelItem>().UILink(), 5, typeof(PrimitiveMechanicsSpeedSkill));    
            this.Initialize("Iron Wheel", typeof(IronWheelRecipe));

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class IronWheelItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Iron Wheel"; } } 
        public override string Description { get { return ""; } }

    }

}
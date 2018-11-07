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

    [RequiresSkill(typeof(BasicSmeltingSkill), 2)]   
    public partial class IronIngotRecipe : Recipe
    {
        public IronIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(),          
            new CraftingElement<TailingsItem>(typeof(BasicSmeltingEfficiencySkill), 5, BasicSmeltingEfficiencySkill.MultiplicativeStrategy)

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronOreItem>(typeof(BasicSmeltingEfficiencySkill), 20, BasicSmeltingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronIngotRecipe), Item.Get<IronIngotItem>().UILink(), 4, typeof(BasicSmeltingSpeedSkill));    
            this.Initialize("Iron Ingot", typeof(IronIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }


    [Serialized]
    [Weight(2500)]      
    [Currency]                                              
    public partial class IronIngotItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Iron Bar"; } } 
        public override string FriendlyNamePlural { get { return "Iron Bars"; } } 
        public override string Description { get { return "Refined block of iron."; } }

    }

}
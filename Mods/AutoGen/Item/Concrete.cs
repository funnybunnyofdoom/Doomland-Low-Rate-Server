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

    [RequiresSkill(typeof(CementSkill), 1)]   
    public partial class ConcreteRecipe : Recipe
    {
        public ConcreteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(CementProductionEfficiencySkill), 40, CementProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ConcreteRecipe), Item.Get<ConcreteItem>().UILink(), 2, typeof(CementProductionSpeedSkill));    
            this.Initialize("Concrete", typeof(ConcreteRecipe));

            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
    }


    [Serialized]
    [Weight(10000)]      
    [Currency]                                              
    public partial class ConcreteItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Concrete"; } } 
        public override string FriendlyNamePlural { get { return "Concrete"; } } 
        public override string Description { get { return "A material made from cement and an aggregate like crushed stone. In order to be usable it needs to be reinforced."; } }

    }

}
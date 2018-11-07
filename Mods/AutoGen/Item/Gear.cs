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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 1)]   
    public partial class GearRecipe : Recipe
    {
        public GearRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GearItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 2, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GearRecipe), Item.Get<GearItem>().UILink(), 1, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Gear", typeof(GearRecipe));

            CraftingComponent.AddRecipe(typeof(ShaperObject), this);
        }
    }


    [Serialized]
    [Weight(500)]      
    [Currency]                                              
    public partial class GearItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Iron Gear"; } } 
        public override string FriendlyNamePlural { get { return "Iron Gears"; } } 
        public override string Description { get { return "A toothed machine part that interlocks with others."; } }

    }

}
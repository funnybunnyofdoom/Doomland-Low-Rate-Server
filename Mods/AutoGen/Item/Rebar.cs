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

    [RequiresSkill(typeof(CastingSkill), 4)]   
    public partial class RebarRecipe : Recipe
    {
        public RebarRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RebarItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(CastingEfficiencySkill), 5, CastingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RebarRecipe), Item.Get<RebarItem>().UILink(), 0.5f, typeof(CastingSpeedSkill));    
            this.Initialize("Rebar", typeof(RebarRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }


    [Serialized]
    [Weight(3000)]      
    [Currency]                                              
    public partial class RebarItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Rebar"; } } 
        public override string Description { get { return "Ribbed steel bars for reinforcing stuctures."; } }

    }

}
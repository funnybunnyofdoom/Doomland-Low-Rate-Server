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

    [RequiresSkill(typeof(PaperSkill), 1)]   
    public partial class PaperRecipe : Recipe
    {
        public PaperRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PaperItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WoodPulpItem>(typeof(PaperEfficiencySkill), 10, PaperEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaperRecipe), Item.Get<PaperItem>().UILink(), 0.25f, typeof(PaperSpeedSkill));    
            this.Initialize("Paper", typeof(PaperRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [Weight(100)]      
    [Currency]                                              
    public partial class PaperItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Paper"; } } 
        public override string Description { get { return "It's paper."; } }

    }

}
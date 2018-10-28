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

    [RequiresSkill(typeof(PetrolRefiningSkill), 4)]   
    public partial class EpoxyRecipe : Recipe
    {
        public EpoxyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<EpoxyItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PetroleumItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(EpoxyRecipe), Item.Get<EpoxyItem>().UILink(), 2, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Epoxy", typeof(EpoxyRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class EpoxyItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Epoxy"; } } 
        public override string FriendlyNamePlural { get { return "Epoxy"; } } 
        public override string Description { get { return "A useful material for hardening, curing, and other various uses."; } }

    }

}
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

    [RequiresSkill(typeof(PetrolRefiningSkill), 3)]   
    public partial class SyntheticRubberRecipe : Recipe
    {
        public SyntheticRubberRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SyntheticRubberItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PetroleumItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SyntheticRubberRecipe), Item.Get<SyntheticRubberItem>().UILink(), 2, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Synthetic Rubber", typeof(SyntheticRubberRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class SyntheticRubberItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Synthetic Rubber"; } } 
        public override string FriendlyNamePlural { get { return "Rubber"; } } 
        public override string Description { get { return "An extremely useful synthetic material derived from petrochemicals"; } }

    }

}
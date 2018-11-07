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

    [RequiresSkill(typeof(ElectronicEngineeringSkill), 1)]   
    public partial class FiberglassRecipe : Recipe
    {
        public FiberglassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FiberglassItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlasticItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(ElectronicEngineeringEfficiencySkill), 3, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FiberglassRecipe), Item.Get<FiberglassItem>().UILink(), 5, typeof(ElectronicEngineeringSpeedSkill));    
            this.Initialize("Fiberglass", typeof(FiberglassRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]      
    [Currency]                                              
    public partial class FiberglassItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Fiberglass"; } } 
        public override string FriendlyNamePlural { get { return "Fiberglass"; } } 
        public override string Description { get { return "Plastic reinforced with glass fiber strands."; } }

    }

}
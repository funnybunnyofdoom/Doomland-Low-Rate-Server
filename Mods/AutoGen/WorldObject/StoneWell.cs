namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    

    [Serialized]
    [Category("Hidden")] 
    public partial class StoneWellItem :
        WorldObjectItem<StoneWellObject> 
    {
        public override string FriendlyName { get { return "Stone Well"; } } 
        public override string Description  { get { return  "PLACEHOLDER"; } }

        static StoneWellItem()
        {
            
        }

        
    }


    public partial class StoneWellRecipe : Recipe
    {
        public StoneWellRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StoneWellItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
            };
            this.CraftMinutes = new ConstantValue(); 
            this.Initialize("Stone Well", typeof(StoneWellRecipe));
            CraftingComponent.AddRecipe(typeof(Object), this);
        }
    }
}
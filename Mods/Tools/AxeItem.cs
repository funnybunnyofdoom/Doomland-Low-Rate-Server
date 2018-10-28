// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Stats;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [Category("Hidden")]
    public partial class AxeItem
    {
        private static IDynamicValue caloriesBurn;
        private static IDynamicValue damage;
        static AxeItem()
        {
            string axeUiLink = new AxeItem().UILink();
            caloriesBurn = new ConstantValue(0);
            damage = new ConstantValue(100);
        }
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override Item RepairItem { get { return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount { get { return 1; } }

        public override IDynamicValue CaloriesBurn   { get { return caloriesBurn; } }
        public override IDynamicValue Damage         { get { return damage; } }
        
        public override string LeftActionDescription { get { return "Chop"; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                var block = World.GetBlock(context.BlockPosition.Value);
                if (block.Is<TreeDebris>())
                {
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<WoodPulpItem>(5);
                    IAtomicAction lawAction = PlayerActions.PickUp.CreateAtomicAction(context.Player, Get<WoodPulpItem>(), context.BlockPosition.Value);
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes, lawAction);
                }
                else
                    return InteractResult.NoOp;
            }
            else
                return base.OnActLeft(context);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<TreeDebris>(block);
        }
    }
}
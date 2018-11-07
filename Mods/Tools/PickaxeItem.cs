// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Stats;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Objects;

    [Category("Hidden")]
    public partial class PickaxeItem : ToolItem
    {
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(MiningSkill), typeof(PickaxeItem), new PickaxeItem().UILink());
        static PickaxeItem() { }

        public override IDynamicValue CaloriesBurn            { get { return caloriesBurn; } }

        public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.DestroyBlock; } }
        public override string LeftActionDescription          { get { return "Mine"; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override Item RepairItem { get { return Item.Get<StoneItem>(); } }
        public override int FullRepairAmount { get { return 1; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock && context.Block.Is<Minable>())
            {
                Result result;
                if (context.Block is IRepresentsItem)
                {
                    Item item = Item.Get((IRepresentsItem)context.Block);
                    IAtomicAction lawAction = PlayerActions.PickUp.CreateAtomicAction(context.Player, item, context.BlockPosition.Value);
                    result = this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 1, null, lawAction);
                }
                else
                    result = this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 1);

                if (result.Success)
                    if (RubbleObject.TrySpawnFromBlock(context.Block.GetType(), context.BlockPosition.Value))
                        context.Player.User.UserUI.OnCreateRubble.Invoke();

                return (InteractResult)result;
            }
            else if (context.Target is RubbleObject)
            {
                var rubble = (RubbleObject)context.Target;
                if (rubble.IsBreakable)
                {
                    rubble.Breakup();
                    BurnCalories(context.Player);
                    return InteractResult.Success;
                }
                else
                    return InteractResult.NoOp;
            }
            else
                return InteractResult.NoOp;
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Minable>(block);
        }
    }
}
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Linq;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Items;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Simulation;
using Eco.Simulation.Agents;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.DynamicValues;

[Serialized]
[IgnoreAuth]
[Category("Hidden")]
public class DevtoolItem : HammerItem
{
    public override string Description  { get { return "DOES CHEATER THINGS THROUGH CHEATING POWERS"; } }
    public override string FriendlyName { get { return "Dev Tool"; } }

    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

    public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.DestroyBlock; } }
    public override string LeftActionDescription          { get { return "Smite"; } }

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (context.HasBlock && !context.Block.Is<Impenetrable>())
        {
            World.DeleteBlock(context.BlockPosition.Value);
            var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value + Vector3i.Up);
            if (plant != null)
                EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);
            return InteractResult.Success;
        }
        else if (context.HasTarget)
        {
            if (context.Target != null)
            {
                if (context.Target is WorldObject)
                    (context.Target as WorldObject).Destroy();
                else if (context.Target is TreeEntity)
                    (context.Target as TreeEntity).Destroy();
                else if (context.Target is Animal)
                    (context.Target as Animal).Destroy();
            }
            return InteractResult.Success;
        }
        else
            return InteractResult.NoOp;
    }

    public override InteractResult OnActRight(InteractionContext context)
    {
        var currentBlock = context.Player.User.Inventory.Carried.Stacks.First().Item as BlockItem;
        if (currentBlock != null && context.HasBlock && context.Normal != Vector3i.Zero)
        {
            var result = currentBlock.OnActRight(context);
            if (result == InteractResult.Success)
            {
                context.Player.User.Inventory.AddItem(currentBlock);
                return result;
            }
        }

        return InteractResult.NoOp;
    }

    public override InteractResult OnActInteract(InteractionContext context)
    {
        if (context.HasBlock)
        {
            var item = BlockItem.CreatingItem(context.Block.GetType());
            if(item != null)
                context.Player.User.Inventory.ReplaceStack(context.Player, context.Player.User.Inventory.Carried.Stacks.First(), item.TypeID, 1);
        }
        return InteractResult.NoOp;
    }


    // un-override hammer stuff we don't really want
    public override bool ShouldHighlight(Type block)
    {
        return true;
    }
}
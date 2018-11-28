// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using Eco.Core.Utils;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;

[Serialized]
[Solid, Wall, Road(1f)]
public class StoneRoadWorldObjectBlock : WorldObjectBlock
{
    protected StoneRoadWorldObjectBlock() { }
    public StoneRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
[Solid, Wall, Road(1f)]
public class DirtRoadWorldObjectBlock : WorldObjectBlock
{
    protected DirtRoadWorldObjectBlock() { }
    public DirtRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
[Solid, Wall, Road(1f)]
public class AsphaltRoadWorldObjectBlock : WorldObjectBlock
{
    protected AsphaltRoadWorldObjectBlock() { }
    public AsphaltRoadWorldObjectBlock(WorldObject obj) : base(obj) { }
}

[Serialized]
public abstract class BaseRampObject : WorldObject
{
    // No UI
    public override InteractResult OnActInteract(InteractionContext context)
    {
        return InteractResult.NoOp;
    }
}

[Serialized]
public class DirtRampObject : BaseRampObject
{
    public override LocString DisplayName { get { return Localizer.DoStr("Dirt Ramp"); } }

    static DirtRampObject()
    {
        AddOccupancyList(typeof(DirtRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 0))
                .Select(x => new BlockOccupancy(x, typeof(DirtRoadWorldObjectBlock))).ToArray());
    }

    private DirtRampObject() { }

    protected override void Initialize()
    {
        base.Initialize();

        // destroy the object first - as destroy deletes blocks based on occupancy
        this.Destroy();

        // migration - delete the old object and replace with blocks.
        Vector3i placementDir = this.Rotation.RotateVector(Vector3i.Left).Round;
        Vector3i offset = this.Rotation.RotateVector(Vector3i.Forward).Round;
        var blockTypes = Item.Get<DirtRampItem>().GetBlockTypesForDirection(placementDir);
        var position = this.Position.Round;
        foreach (var blockType in blockTypes)
        {
            // dirt ramps were 2 wide
            World.SetBlock(blockType, position);
            World.SetBlock(blockType, position + offset);
            position += placementDir;
        }
    }
}

public abstract class RampItem<T> : WorldObjectItem<T> 
    where T : WorldObject
{
    public override bool ShouldCreate { get { return false; } }

    public abstract Type[] GetBlockTypesForDirection(Vector3i direction);

    public override Result OnAreaValid(Player player, Vector3i position, Quaternion rotation)
    {
        // instead of placing as a world object, spawn blocks
        Vector3i placementDir = rotation.RotateVector(Vector3i.Left).Round;
        var blockTypes = GetBlockTypesForDirection(placementDir);
        foreach (var blockType in blockTypes)
        {
            UsableItemUtils.PlayerPlaceBlock(blockType, position, player, false);
            position += placementDir;
        }

        return Result.Succeeded;
    }
}


[Serialized]
[ItemGroup("Road Items")]
[Tag("Road")]
public class DirtRampItem : RampItem<DirtRampObject>
{
    public override LocString DisplayName { get { return Localizer.DoStr("Dirt Ramp"); } }
    public override LocString DisplayDescription  { get { return Localizer.DoStr("4 x 1 Dirt Ramp."); } }

    public override Type[] GetBlockTypesForDirection(Vector3i direction)
    {
        if (direction == Vector3.Left)
            return new Type[] { typeof(DirtRampABlock), typeof(DirtRampBBlock), typeof(DirtRampCBlock), typeof(DirtRampDBlock) };
        if (direction == Vector3.Forward)
            return new Type[] { typeof(DirtRampA90Block), typeof(DirtRampB90Block), typeof(DirtRampC90Block), typeof(DirtRampD90Block) };
        if (direction == Vector3.Right)
            return new Type[] { typeof(DirtRampA180Block), typeof(DirtRampB180Block), typeof(DirtRampC180Block), typeof(DirtRampD180Block) };
        if (direction == Vector3.Back)
            return new Type[] { typeof(DirtRampA270Block), typeof(DirtRampB270Block), typeof(DirtRampC270Block), typeof(DirtRampD270Block) };
        else
            return new Type[] { };
    }
}

[Serialized]
public class StoneRampObject : BaseRampObject
{
    public override LocString DisplayName { get { return Localizer.DoStr("Stone Ramp"); } }

    static StoneRampObject()
    {
        AddOccupancyList(typeof(StoneRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 0))
                .Select(x => new BlockOccupancy(x, typeof(StoneRoadWorldObjectBlock))).ToArray());
    }

    private StoneRampObject() { }

    protected override void Initialize()
    {
        base.Initialize();

        // destroy the object first - as destroy deletes blocks based on occupancy
        this.Destroy();

        // migration - delete the old object and replace with blocks.
        Vector3i placementDir = this.Rotation.RotateVector(Vector3i.Left).Round;
        Vector3i offset = this.Rotation.RotateVector(Vector3i.Forward).Round;
        var blockTypes = Item.Get<StoneRampItem>().GetBlockTypesForDirection(placementDir);
        var position = this.Position.Round;
        foreach (var blockType in blockTypes)
        {
            // stone ramps were 2 wide
            World.SetBlock(blockType, position);
            World.SetBlock(blockType, position + offset);
            position += placementDir;
        }
    }
}

[Serialized]
[ItemGroup("Road Items")]
[Tag("Road")]
public class StoneRampItem : RampItem<StoneRampObject>
{
    public override LocString DisplayName { get { return Localizer.DoStr("Stone Ramp"); } }
    public override LocString DisplayDescription  { get { return Localizer.DoStr("4 x 1 Stone Ramp."); } }

    public override Type[] GetBlockTypesForDirection(Vector3i direction)
    {
        if (direction == Vector3.Left)
            return new Type[] { typeof(StoneRampABlock), typeof(StoneRampBBlock), typeof(StoneRampCBlock), typeof(StoneRampDBlock) };
        if (direction == Vector3.Forward)
            return new Type[] { typeof(StoneRampA90Block), typeof(StoneRampB90Block), typeof(StoneRampC90Block), typeof(StoneRampD90Block) };
        if (direction == Vector3.Right)
            return new Type[] { typeof(StoneRampA180Block), typeof(StoneRampB180Block), typeof(StoneRampC180Block), typeof(StoneRampD180Block) };
        if (direction == Vector3.Back)
            return new Type[] { typeof(StoneRampA270Block), typeof(StoneRampB270Block), typeof(StoneRampC270Block), typeof(StoneRampD270Block) };
        else
            return new Type[] { };
    }
}

[Serialized]
public class AsphaltRampObject : BaseRampObject
{
    public override LocString DisplayName { get { return Localizer.DoStr("Asphalt Ramp"); } }
    static AsphaltRampObject()
    {
        AddOccupancyList(typeof(AsphaltRampObject),
            Vector3i.XYZIterInclusive(new Vector3i(-3, 0, 0), new Vector3i(0, 0, 0))
                .Select(x => new BlockOccupancy(x, typeof(AsphaltRoadWorldObjectBlock))).ToArray());
    }

    private AsphaltRampObject() { }

    protected override void Initialize()
    {
        base.Initialize();

        // destroy the object first - as destroy deletes blocks based on occupancy
        this.Destroy();

        // migration - delete the old object and replace with blocks.
        Vector3i placementDir = this.Rotation.RotateVector(Vector3i.Left).Round;
        Vector3i offset = this.Rotation.RotateVector(Vector3i.Forward).Round;
        var blockTypes = Item.Get<AsphaltRampItem>().GetBlockTypesForDirection(placementDir);
        var position = this.Position.Round;
        foreach (var blockType in blockTypes)
        {
            // asphalt ramps were 4 wide
            World.SetBlock(blockType, position);
            World.SetBlock(blockType, position + offset);
            World.SetBlock(blockType, position + offset * 2);
            World.SetBlock(blockType, position + offset * 3);
            position += placementDir;
        }
    }
}

[Serialized]
[ItemGroup("Road Items")]
[Tag("Road")]
public class AsphaltRampItem : RampItem<AsphaltRampObject>
{
    public override LocString DisplayName { get { return Localizer.DoStr("Asphalt Ramp"); } }
    public override LocString DisplayDescription  { get { return Localizer.DoStr("4 x 1 Asphalt Ramp."); } }

    public override Type[] GetBlockTypesForDirection(Vector3i direction)
    {
        if (direction == Vector3.Left)
            return new Type[] { typeof(AsphaltRampABlock), typeof(AsphaltRampBBlock), typeof(AsphaltRampCBlock), typeof(AsphaltRampDBlock) };
        if (direction == Vector3.Forward)
            return new Type[] { typeof(AsphaltRampA90Block), typeof(AsphaltRampB90Block), typeof(AsphaltRampC90Block), typeof(AsphaltRampD90Block) };
        if (direction == Vector3.Right)
            return new Type[] { typeof(AsphaltRampA180Block), typeof(AsphaltRampB180Block), typeof(AsphaltRampC180Block), typeof(AsphaltRampD180Block) };
        if (direction == Vector3.Back)
            return new Type[] { typeof(AsphaltRampA270Block), typeof(AsphaltRampB270Block), typeof(AsphaltRampC270Block), typeof(AsphaltRampD270Block) };
        else
            return new Type[] { };
    }
}

#region DirtRampBlocks
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampABlock : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampBBlock : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampCBlock : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampDBlock : DirtRoadBlock { }

[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampA90Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampB90Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampC90Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampD90Block : DirtRoadBlock { }

[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampA180Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampB180Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampC180Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampD180Block : DirtRoadBlock { }

[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampA270Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampB270Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampC270Block : DirtRoadBlock { }
[Road(1, typeof(DirtRoadBlock))]
[Serialized, Solid, Diggable] public partial class DirtRampD270Block : DirtRoadBlock { }
#endregion

#region StoneRampBlocks
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampABlock : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampBBlock : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampCBlock : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampDBlock : StoneRoadBlock { }

[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampA90Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampB90Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampC90Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampD90Block : StoneRoadBlock { }

[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampA180Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampB180Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampC180Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampD180Block : StoneRoadBlock { }

[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampA270Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampB270Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampC270Block : StoneRoadBlock { }
[Road(1, typeof(StoneRoadBlock))]
[Serialized, Solid, Diggable] public partial class StoneRampD270Block : StoneRoadBlock { }
#endregion

#region AsphaltRampBlocks
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampABlock : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampBBlock : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampCBlock : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampDBlock : AsphaltRoadBlock { }

[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampA90Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampB90Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampC90Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampD90Block : AsphaltRoadBlock { }

[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampA180Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampB180Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampC180Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampD180Block : AsphaltRoadBlock { }

[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampA270Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampB270Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampC270Block : AsphaltRoadBlock { }
[Road(1, typeof(AsphaltRoadBlock))]
[Serialized, Solid, Diggable] public partial class AsphaltRampD270Block : AsphaltRoadBlock { }
#endregion
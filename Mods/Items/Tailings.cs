namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Gameplay.Items;
    using Eco.Shared.Math;
    using Eco.World.Blocks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;
    using Eco.Simulation.WorldLayers;
    using Eco.Gameplay.Pipes;
    using Eco.Gameplay.Items.SearchAndSelect;
    using World = World.World;

    // To be honest, most of these should probably be removed from Tailing.cs, but they're here for now.
    [Serialized]
    [Weight(30000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    [MakesRoads]
    public class DirtItem : BlockItem<DirtBlock>, ICanExitFromPipe
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Dirt"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Dirt"); } }
        public override bool CanStickToWalls        { get { return false; } }
        
        public string FlowTooltip(float flowrate)   { return null; }

        public int OnPipeExit(Ray posDir, int amount)
        {
            var existingBlock = World.GetBlock(posDir.FirstPos) as EmptyBlock;
            if (existingBlock != null)
            {
                var target = World.FindPyramidPos(posDir.FirstPos);
                World.SetBlock(this.OriginType, target);
                return 1;
            }
            return 0;
        }
    }

    [Serialized]
    [Weight(30000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    public class SandItem : BlockItem<SandBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sand"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Sand"); } }
        public override bool CanStickToWalls { get { return false; } }
    }

    [Serialized, Liquid]
    [Category("Hidden")]
    [MaxStackSize(10)]
    public class WaterItem : BlockItem<WaterBlock>, ICanExitFromPipe
    {
        public override bool CanStickToWalls { get { return false; } }
        public string FlowTooltip(float flowrate) { return null; }

        public int OnPipeExit(Ray posDir, int amount)
        {
            var pos = posDir.FirstPos;
            var toSet = Math.Min(amount, 1000);
            var existingBlock = World.GetBlock(pos);
            if (!(existingBlock is EmptyBlock) && !(existingBlock is WaterBlock))
                return 0;

            // Set the existing block if it's there, or add a new block.
            if (existingBlock is EmptyBlock)
                existingBlock = World.SetBlock(typeof(WaterBlock), pos, toSet * 0.001f) as WaterBlock;

            var waterBlock = existingBlock as WaterBlock;
            if (waterBlock.Water < toSet)
            {
                waterBlock.Water = toSet;
                World.WakeUp(pos);
            }
            waterBlock.PipeSupplied = true;
            return toSet;
        }
    }


    [Serialized, Liquid]
    [Category("Hidden")]
    public class SewageItem : BlockItem<SewageBlock>, ICanExitFromPipe
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sewage"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Sewage"); } }
        public override bool CanStickToWalls { get { return false; } }
        public string FlowTooltip(float flowrate) { return null; }


        public int OnPipeExit(Ray posDir, int amount)
        {
            WorldLayerManager.ClimateSim.AddGroundPollution(posDir.FirstPos.XZ, amount);
            return amount;
        }
    }

    [Serialized, Weight(30), StartsDiscovered]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    public class TailingsItem : BlockItem<TailingsBlock>
    {
        public override LocString DisplayName       { get { return Localizer.DoStr("Tailings"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tailings"); } }
        public override LocString DisplayDescription        { get { return Localizer.DoStr("Waste product from smelting.  When left on soil the run-off will create pollution; killing nearby plants and seeping into the water supply.  Contain in buildings or bury in rock to neutralize."); } }
        public override bool CanStickToWalls      { get { return false; } }
    }
}
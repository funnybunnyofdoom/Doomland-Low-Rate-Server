// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;
    using Eco.Shared.Serialization;

    [Serialized]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    public partial class GarbageItem : BlockItem<GarbageBlock>
    {
        public override string FriendlyName { get { return "Garbage"; } }
        public override string FriendlyNamePlural { get { return "Garbage"; } }
        public override string Description { get { return "A disgusting pile of garbage."; } }
        public override bool CanStickToWalls { get { return false; } }
    }
    [Serialized]
    [MaxStackSize(1)]
    public partial class TrashItem : Item { }
}
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Objects;
    using Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(MinimapComponent))]
    public partial class StoneWellObject : WorldObject
    {
        public override string FriendlyName { get { return "Stone Well"; } }

        private StoneWellObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<MinimapComponent>().Initialize("Stone Well");
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            //this.GetComponent<PipeComponent>().Tanks.Add(new LiquidTank("Water", typeof(WaterItem), 1000, new Vector3i[] { Vector3i.Up }, new Vector3i[] { Vector3i.Right }));
            //this.GetComponent<PipeComponent>().Tanks.Add(new LiquidPump("Water Pump", typeof(WaterItem), 1000, new Vector3i[] { Vector3i.Down }, new Vector3i[] { Vector3i.Left }));
        }
    }
}
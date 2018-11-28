// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public class WoodenElevatorObject : PhysicsWorldObject, INetObjectPriority
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Elevator"); } }

        public float Priority { get { return NetObjectPriority.Medium; } }

        [Serialized] private float cagePos;
        private float v;

        private WoodenElevatorObject() { }

        protected override void OnCreate()
        {
            base.OnCreate();
            this.cagePos = this.Position.y - 0.5f;
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.SetAnimatedState("dir", 0f);
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendInitialState(bsonObj, viewer);
            this.SendUpdate(bsonObj, viewer);
            bsonObj["dir"] = this.GetAnimatedState<float>("dir");
        }

        public override void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer)
        {
            base.SendUpdate(bsonObj, viewer);
            bsonObj["cagePos"] = this.cagePos;
            bsonObj["v"] = this.v;
        }

        public override void ReceiveUpdate(BSONObject bsonObj)
        {
            BSONValue cageUpdate;
            if (bsonObj.TryGetValue("cage", out cageUpdate))
            {
                this.cagePos = cageUpdate.ObjectValue["pos"].Vector3Value.y;
                bsonObj["time"] = cageUpdate.ObjectValue["time"].FloatValue;
                if (cageUpdate.ObjectValue.ContainsKey("v"))
                    this.v = cageUpdate.ObjectValue["v"].Vector3Value.y;
            }
            base.ReceiveUpdate(bsonObj);

            if (bsonObj.ContainsKey("stop"))
            {
                this.v = 0f;
                this.AnimatedStates["dir"] = 0f;
            }
            this.SetDirty();
        }

        public override InteractResult OnActInteract(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("Down"))
            {
                var physicsEntity = this.netEntity as NetPhysicsEntity;
                physicsEntity.SetPhysicsController(context.Player);
                this.AnimatedStates["dir"] = -1f;
            }
            else if (context.Parameters != null && context.Parameters.ContainsKey("Up"))
            {
                var physicsEntity = this.netEntity as NetPhysicsEntity;
                physicsEntity.SetPhysicsController(context.Player);
                this.AnimatedStates["dir"] = 1f;
            }else if (context.Parameters != null && context.Parameters.ContainsKey("Stop"))
            {
                var physicsEntity = this.netEntity as NetPhysicsEntity;
                physicsEntity.SetPhysicsController(context.Player);
                this.AnimatedStates["dir"] = 0f;
            }
            return base.OnActInteract(context);
        }
    }
}
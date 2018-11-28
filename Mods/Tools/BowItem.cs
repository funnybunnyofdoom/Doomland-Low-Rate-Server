// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Eco.Gameplay.Animals;
using Eco.Gameplay.Auth;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;

[Serialized]
[Category("Tools")]
public class BowItem : ToolItem
{
    static SkillModifiedValue caloriesBurn;
    public static SkillModifiedValue Damage { get; private set; }

    static BowItem()
    {
        string bowUiLink = new BowItem().UILink();
        caloriesBurn = CreateCalorieValue(20, typeof(HuntingSkill), typeof(BowItem), new LocString(bowUiLink));
        Damage = CreateDamageValue(1, typeof(BowDamageSkill), typeof(BowItem), new LocString(bowUiLink));
    }
    private static IDynamicValue skilledRepairCost = new ConstantValue(5);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }
    public override LocString DisplayName { get { return Localizer.DoStr("Bow"); } }
    public override LocString DisplayDescription { get { return Localizer.DoStr("Shoots arrows.  Useful for hunting."); } }
    
    public override Item RepairItem { get { return Item.Get<LogItem>(); } }
    public override int FullRepairAmount { get { return 5; } }

    [RPC]
    int FireArrow(Player player, Vector3 position, Vector3 velocity)
    {
        if (player.User.Inventory.TryRemoveItem<ArrowItem>(player.User))
        {
            this.BurnCalories(player);
            var arrow = new ArrowEntity();
            arrow.Controller = player;
            arrow.Position = position;
            arrow.Velocity = velocity;
            arrow.SetActiveAndCreate();
            return arrow.ID;
        }
        else
            return -1;
    }

    public override bool ShouldHighlight(Type block)
    {
        return false;
    }
}

public class ArrowEntity : NetEntity
{
    public INetObjectViewer Controller { get; set; }
    public Vector3 Velocity { get; set; }
    public NetObjAttachInfo attached;
    private double DestroyTime;

    public ArrowEntity() 
        : base("Arrow")
    {
        this.DestroyTime = TimeUtil.Seconds + lifeTime;
    }

    private const double lifeTime = 120f;

    [RPC]
    public override void Destroy()
    {
        // let clients help decide when to destroy
        base.Destroy();
    } 

    [RPC]
    public void Hit(NetObjAttachInfo hitAttachInfo, Vector3 position)
    {
        var other = NetObjectManager.GetObject<INetObject>(hitAttachInfo.ParentID);
        if (this.Controller is Player && AuthManager.IsAuthorized(position.Round, (this.Controller as Player).User).Notify(this.Controller as Player))
        {
            // bow only damages animals
            var animal = other as AnimalEntity;
            if (animal != null)
            {
                Player player = this.Controller as Player;
                if (player != null)
                {
                    if (animal.TryApplyDamage(player, BowItem.Damage.GetCurrentValue(player.User), null))
                        this.attached = hitAttachInfo;
                    else
                        this.Destroy();
                }
            }
            else if (other is Player)
            {
                // arrows look silly sticking in player capsule colliders
                var s = FormattableStringFactory.Create("You must obtain authorization to shoot {0}.", (other as Player).DisplayName);
                (this.Controller as Player).SendTemporaryError(s);
                this.Destroy();
            }
            else
                this.attached = hitAttachInfo;
        }

        if (this.attached != null)
            this.RPC("Attach", this.attached);

        this.Position = position;
        this.Rotation = Quaternion.LookRotation(this.Velocity.Normalized);
        this.Velocity = Vector3.Zero;
    }

    [RPC]
    public void HitStatic(Vector3 position, Quaternion rotation)
    {
        this.Position = position;
        this.Rotation = rotation;
        this.Velocity = Vector3.Zero;
        this.RPC("Attach", position, rotation);
    }

    public override bool IsRelevant(INetObjectViewer viewer)
    {
        if (this.attached != null)
        {
            var obj = NetObjectManager.GetObject<INetObject>(this.attached.ParentID);
            if (obj != null)
                return obj.IsRelevant(viewer);

            this.Destroy();
            return false;
        }
        return base.IsRelevant(viewer);
    }

    public override bool IsNotRelevant(INetObjectViewer viewer)
    {
        if (TimeUtil.Seconds > this.DestroyTime)
            this.Destroy();

        if (this.attached != null)
        {
            var obj = NetObjectManager.GetObject<INetObject>(this.attached.ParentID);
            if (obj != null)
                return obj.IsNotRelevant(viewer);

            this.Destroy();
            return true;
        }
        return base.IsNotRelevant(viewer);
    }

    public override void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer)
    {
        if (this.attached == null)
            base.SendUpdate(bsonObj, viewer);
    }

    public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
    {
        base.SendInitialState(bsonObj, viewer);
        if (this.attached != null)
            bsonObj["attached"] = this.attached.ToBson();
        bsonObj["v"]        = this.Velocity;
        bsonObj["noGround"] = true;
        bsonObj["noFadeIn"] = true;
        if (this.Controller != null && this.Controller is INetObject)
            bsonObj["controller"] = ((INetObject)this.Controller).ID;
    }
}
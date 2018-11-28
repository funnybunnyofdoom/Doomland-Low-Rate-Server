// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Core.Utils;
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Shared.Math;
    using Shared.Serialization;

    [Serialized]
    public class StarterCampItem : WorldObjectItem<StarterCampObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Starter Camp"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A combination of a small tent and a tiny stockpile."); } }

        public override Result OnAreaValid(Player player, Vector3i position, Quaternion rotation)
        {
            Result authAtPosOne = AuthManager.IsAuthorized(position, player.User);
            Result authAtPosTwo = AuthManager.IsAuthorized((position + rotation.RotateVector(Vector3i.Right * 3)).Round, player.User);

            if (!authAtPosOne.Success)
                return authAtPosOne;
            else if (!authAtPosTwo.Success)
                return authAtPosTwo;

            Deed deed = PropertyManager.FindNearbyDeedOrCreate(player.User, position.XZ);
            var dist = position.XZ - World.GetPropertyPos(position.XZ) - (World.PropertyPlotLength / 2);
            if (dist.x == 0 || dist.y == 0)
                dist = rotation.RotateVector(new Vector3i(1, 0, 1)).XZi;
            dist = new Vector2i(Math.Sign(dist.x), Math.Sign(dist.y));
            Vector2i.XYIter(2).ForEach(x => PropertyManager.Claim(deed.Id, player.User, position.XZ + (new Vector2i(dist.x * x.x, dist.y * x.y) * World.PropertyPlotLength)));

            var camp = WorldObjectManager.TryToAdd(typeof(CampsiteObject), player.User, position, rotation, false);
            var stockpile = WorldObjectManager.TryToAdd(typeof(TinyStockpileObject), player.User, position + rotation.RotateVector(Vector3i.Right * 3), rotation, false);
            player.User.OnWorldObjectPlaced.Invoke(camp);
            player.User.Markers.Add(camp.Position3i + Vector3i.Up, camp.UILinkContent());
            player.User.Markers.Add(stockpile.Position3i + Vector3i.Up, stockpile.UILinkContent());
            var storage = camp.GetComponent<PublicStorageComponent>();
            var changeSet = new InventoryChangeSet(storage.Inventory);
            PlayerDefaults.GetDefaultCampsiteInventory().ForEach(x =>
            {
                changeSet.AddItems(x.Key, x.Value, storage.Inventory);
            });
            changeSet.Apply();
            return Result.Succeeded;
        }

        public override bool ShouldCreate { get { return false; } }

        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation)
        {
            return TryPlaceObjectOnSolidGround(player, position, rotation, StarterCampObject.DefaultDim);
        }
    }

    [Serialized]
    public class StarterCampObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Starting Camp"); } }

        public static readonly Vector3i DefaultDim = new Vector3i(6, 3, 2);
    }
}
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;

[Serialized]
[RequireComponent(typeof(TreasuryComponent))]
[RequireComponent(typeof(PropertyAuthComponent))]
public class TreasuryObject : WorldObject
{
    public override string FriendlyName { get { return "Treasury"; } }

    protected override void PostInitialize()
    {
        if (this.isFirstInitialization)
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic(); //Only the leader can use the component anyway.
        }        
    }
}

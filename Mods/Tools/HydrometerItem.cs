// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System.ComponentModel;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Shared.Serialization;

[Serialized]
[Category("Hidden")]
public class HydrometerItem : ToolItem
{
    static IDynamicValue caloriesBurn = new ConstantValue(1);

    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

    public override string FriendlyName { get { return "Hydrometer"; } }
    public override string Description { get { return "Measures the water content of the environment."; } }
        
    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
}
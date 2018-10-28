// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.Linq;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Shared.Utils;
    using Gameplay.Items.SearchAndSelect;
    using Gameplay.Skills;
    using Shared.Serialization;
    using System.Runtime.CompilerServices;
    using Eco.Gameplay.DynamicValues;

    public partial class EckoTheDolphinItem : ToolItem
    {
        [Serialized]
        private string wantedItem = string.Empty;
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
        public override InteractResult OnActRight(InteractionContext context)
        {
            if (this.wantedItem == string.Empty)
                this.wantedItem = SearchAndSelectItemSets.DiscoveredItems.Items.Shuffle().First().FriendlyName;

            var itemStack = context.Player.User.Inventory.NonEmptyStacks.Where(stack => stack.Item.FriendlyName == this.wantedItem).FirstOrDefault();
            if (itemStack != null)
            {
                var gift = AllItems.Where(x => !(x is Skill) && x.Group != "Actionbar Items").Shuffle().First();
                var result = context.Player.User.Inventory.TryModify(changeSet =>
                {
                    changeSet.RemoveItem(itemStack.Item.Type);
                    changeSet.AddItem(gift.Type);
                }, context.Player.User);

                if (result.Success)
                {
                    
                    context.Player.SendTemporaryMessage(FormattableStringFactory.Create("Ecko accepts your tribute of {0:wanted} and grants you {1:given} for your devotion.", this.wantedItem, gift.FriendlyName));
                    this.wantedItem = SearchAndSelectItemSets.DiscoveredItems.Items.Shuffle().First().FriendlyName;
                }
            }
            else
                context.Player.SendTemporaryMessage(FormattableStringFactory.Create("Ecko demands {0:wanted}!", this.wantedItem));

            return InteractResult.Success;
        }
    }
}
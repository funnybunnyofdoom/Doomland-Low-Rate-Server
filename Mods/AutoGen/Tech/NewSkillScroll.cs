namespace Eco.Mods
{
	using Eco.Gameplay.Items;
	using Eco.Gameplay.Skills;
	using Eco.Gameplay.Players;
	using System;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Systems;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
public abstract class NewSkillScroll<SkillT, BookT> : SkillScroll<SkillT, BookT>
       where SkillT : Skill, new()
       where BookT : SkillBook
    {
        public override void OnUsed(Player player, ItemStack itemStack)
        {
            if (player.User.Skillset.HasSkill(this.SkillType))
            {
                player.SendTemporaryErrorLoc(string.Format("You already know {0}.",this.Skill));
            }
            else
            {
                using (var changes = InventoryChangeSet.New(new Inventory[] { player.User.Inventory, itemStack.Parent }.Distinct(), player.User))
                {
                    changes.ModifyStack(itemStack, -1);

                    if (changes.TryApply())
                    {
                        if (!this.Skill.IsDiscovered())
                            ChatManager.ServerMessageToAllLoc(string.Format("{0} discovered {1}!",player.User.UILink(),this.Skill.UILink()), false, DefaultChatTags.Skills);

                        player.User.Skillset.LearnSkill(this.Skill.GetType());
                        player.SendTemporaryMessageLoc(string.Format("You have learned a new skill {0}!",this.Skill.UILink()), ChatCategory.Info);
                    }
                    else
                    {
                        player.SendTemporaryErrorLoc(string.Format("Could not learn {0}: more inventory space required.",this.Skill));
                    }
                }
            }
        }
    }
}
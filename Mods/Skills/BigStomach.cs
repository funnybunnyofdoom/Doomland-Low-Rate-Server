namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;

    public partial class BigStomachSkill : Skill
    {
        public override void OnLevelChanged(Player player)
        {
            player.User.Stomach.ChangedMaxCalories();
        }
    }
}
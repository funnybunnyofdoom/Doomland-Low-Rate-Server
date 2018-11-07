namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;

    public partial class StrongBackSkill : Skill
    {
        public override void OnLevelChanged(Player player)
        {
            player.User.ChangedCarryWeight();
        }
    }
}
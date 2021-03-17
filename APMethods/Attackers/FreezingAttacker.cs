using APMethods.Message;

namespace APMethods
{
    class FreezingAttacker : AttackerDecorator
    {
        public FreezingAttacker(Attacker decoratedAttacker) : base(decoratedAttacker)
        {

        }

        // Attacks player with ice.
        public override void Attack(int xPos, int yPos, Player player)
        {
            string text = "Attacking player with ice. ";
            ConsoleMessage msg = new ConsoleMessage(xPos, yPos, text);
            msg.Display();
            player.DecreaseHealth(3);
            this.decoratedAttacker.Attack(xPos + text.Length, yPos, player);
        }
    }
}

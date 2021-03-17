using APMethods.Message;

namespace APMethods
{
    class FlamingAttacker : AttackerDecorator
    {
        public FlamingAttacker(Attacker decoratedAttacker) : base(decoratedAttacker)
        {

        }

        // Attacks player with flame.
        public override void Attack(int xPos, int yPos, Player player)
        {
            string text = "Attacking player with flame. ";
            ConsoleMessage msg = new ConsoleMessage(xPos, yPos, text);
            msg.Display();
            player.DecreaseHealth(5);
            this.decoratedAttacker.Attack(xPos + text.Length, yPos, player);
        }
    }
}

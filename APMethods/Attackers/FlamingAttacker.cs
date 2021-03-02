using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class FlamingAttacker : AttackerDecorator
    {
        public FlamingAttacker(Attacker decoratedAttacker) : base(decoratedAttacker)
        {

        }

        public override void Attack(int xPos, int yPos, Player player)
        {
            string message = "Attacking player with flame. ";
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(message);
            player.DecreaseHealth(5);
            this.decoratedAttacker.Attack(xPos + message.Length, yPos, player);
        }
    }
}

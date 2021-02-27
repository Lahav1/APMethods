using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class FreezingAttacker : AttackerDecorator
    {
        public FreezingAttacker(Attacker decoratedAttacker) : base(decoratedAttacker)
        {

        }

        public override void Attack(int xPos, int yPos, Player player)
        {
            string message = "Attacking player with ice. ";
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(message);
            player.DecreaseHealth(3);
            this.decoratedAttacker.Attack(xPos + message.Length, yPos, player);
        }
    }
}

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

        public override void Attack(int xPos, int yPos)
        {
            string message = "Attacking player with ice. ";
            Console.SetCursorPosition(xPos, yPos);
            Console.Write(message);
            this.decoratedAttacker.Attack(xPos + message.Length, yPos);
        }
    }
}

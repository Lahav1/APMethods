using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    abstract class AttackerDecorator : Attacker
    {
        protected Attacker decoratedAttacker;

        public AttackerDecorator(Attacker enemy)
        {
            this.decoratedAttacker = enemy;
        }

        // Call the decorated attacker's attack function.
        public virtual void Attack(int xPos, int yPos, Player player)
        {
            this.decoratedAttacker.Attack(xPos, yPos, player);
        }
    }
}

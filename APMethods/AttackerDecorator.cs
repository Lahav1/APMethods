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

        public virtual void Attack(int xPos, int yPos)
        {
            this.decoratedAttacker.Attack(xPos, yPos);
        }
    }
}

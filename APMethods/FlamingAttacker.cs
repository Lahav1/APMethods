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

        public new void Attack()
        {
            Console.WriteLine("Attacking player with flame.");
            this.decoratedAttacker.Attack();
        }
    }
}

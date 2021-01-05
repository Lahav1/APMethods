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
            this.decoratedAttacker.Attack();
            // decrease 20 hp
            Console.WriteLine("Attacking player with flame.");
        }
    }
}

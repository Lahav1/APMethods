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

        public new void Attack()
        {
            Console.WriteLine("Attacking player with ice.");
            this.decoratedAttacker.Attack();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface Attacker
    {
        void Attack(int xPos, int yPos, Player player);
    }
}

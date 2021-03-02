using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface ChasingStrategy
    {
        public void Chase(Enemy enemy, Board board, Player player);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface ChasingStrategy
    {
        public void ChasingAlgorithm(Enemy enemy, Board board);
    }
}

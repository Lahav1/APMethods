using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Player : Character
    {
        int score;
        int level;

        public Player(int x, int y) : base(x, y)
        {
            this.score = 0;
            this.level = 1;
            this.symbol = 'P';
        }
    }
}

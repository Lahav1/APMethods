using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Player : Character
    {
        public int Score { get; set; }

        public Player(int x, int y) : base(x, y)
        {
            this.Score = 0;
            this.symbol = 'P';
        }
    }
}

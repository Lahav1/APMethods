using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Enemy : Character
    {
        int speed;

        public Enemy(int x, int y) : base(x, y)
        {
            this.speed = 1;
            this.symbol = 'E';
        }

        public void SetSpeed(int newSpeed)
        {
            this.speed = newSpeed;
        }
    }
}

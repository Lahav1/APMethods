using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Enemy : Character, Attacker
    {
        int speed;
        ChasingStrategy strategy;

        public Enemy(int x, int y) : base(x, y)
        {
            this.speed = 1;
            this.symbol = 'E';
        }

        public void SetSpeed(int newSpeed)
        {
            this.speed = newSpeed;
        }

        public void Attack()
        {
            Console.WriteLine("Attacking player with basic attack.");
        }

        public void SetChasingStrategy(ChasingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Move()
        {
            this.strategy.ChasingAlgorithm();
        }
    }
}

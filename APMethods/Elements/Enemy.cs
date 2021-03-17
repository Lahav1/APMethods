using APMethods.GameBoard;
using System.Collections.Generic;
using APMethods.Message;

namespace APMethods
{
    class Enemy : Character, Attacker, Observer
    {
        ChasingStrategy strategy;

        public Enemy(int x, int y, Player player, List<Obstacle> obstacles) : base(x, y, obstacles)
        {
            this.symbol = 'E';
            player.SubscribeToScore(this);
        }


        public void Attack(int xPos, int yPos, Player player)
        {
            string text = "\n";
            ConsoleMessage msg = new ConsoleMessage(xPos, yPos, text);
            msg.Display();
            player.DecreaseHealth(2);
        }

        public void SetChasingStrategy(ChasingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Move(Board board, Player player)
        {
            this.strategy.Chase(this, board, player);
        }

        public void Update(int payload)
        {
            if (payload == 10)
            {
                this.SetChasingStrategy(new AdvancedChaser());
            }
        }
    }
}

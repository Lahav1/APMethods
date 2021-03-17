using APMethods.GameBoard;
using System.Collections.Generic;
using APMethods.Message;

namespace APMethods
{
    // Enemy class that attacks player.
    class Enemy : Character, Attacker, Observer
    {
        ChasingStrategy strategy;                       // The enemy's current strategy.
        Dictionary<int, ChasingStrategy> strategies;    // A list off enemies available strategies.

        // Enemy constructor.
        public Enemy(int x, int y, Player player, List<Obstacle> obstacles, Dictionary<int, ChasingStrategy> strategies) : base(x, y, obstacles)
        {
            this.symbol = 'E';
            player.SubscribeToScore(this);
            this.strategies = strategies;
        }

        // A function that attacks player and decreases his health.
        public void Attack(int xPos, int yPos, Player player)
        {
            string text = "\n";
            ConsoleMessage msg = new ConsoleMessage(xPos, yPos, text);
            msg.Display();
            player.DecreaseHealth(2);
        }

        // Setting the enemy's strategy.
        public void SetChasingStrategy(ChasingStrategy strategy)
        {
            this.strategy = strategy;
        }

        // A function that moves the player according to his strategy.
        public void Move(Board board, Player player)
        {
            this.strategy.Chase(this, board, player);
        }

        // Update function that listens to a score update.
        public void Update(int payload)
        {
            if (this.strategies.ContainsKey(payload))
            {
                this.SetChasingStrategy(this.strategies[payload]);
            }
        }
    }
}

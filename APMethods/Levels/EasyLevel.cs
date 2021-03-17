using APMethods.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APMethods.Levels
{
    class EasyLevel : Level
    {
        Random rnd;
        List<Obstacle> obstacles;
        List<Enemy> enemies;
        List<Attacker> Attackers;

        // Easy level constructor.
        public EasyLevel(Board board, Player player)
        {
            this.rnd = new Random();
            this.obstacles = new List<Obstacle>();
            this.enemies = new List<Enemy>();
            this.Attackers = new List<Attacker>();
            this.GenerateLevel(board, player);
        }

        // Generate an easy level.
        public void GenerateLevel(Board board, Player player)
        {
            int width = board.GetWidth();
            int height = board.GetHeight();

            // Generate enemies.
            for (int i = 0; i < Math.Max(3, width * height / 500); i++)
            {
                int x = 0;
                int y = 0;
                // Generate enemies locations.
                do
                {
                    x = this.rnd.Next(1, width - 1);
                } while (this.obstacles.Any(e => e.GetX() == x));

                do
                {
                    y = this.rnd.Next(1, height - 1);
                } while (this.obstacles.Any(e => e.GetY() == y));
                
                // Set enemies strategies.
                Enemy e = new Enemy(x, y, player, this.obstacles, new Dictionary<int, ChasingStrategy>());
                e.SetChasingStrategy(new BasicChaser());
                this.enemies.Add(e);
                this.Attackers.Add(e);
            }
        }

        // Returns the level obstacles.
        public List<Obstacle> GetObstacles()
        {
            return this.obstacles;
        }

        // Returns the level enemies.
        public List<Enemy> GetEnemies()
        {
            return this.enemies;
        }

        // Returns the level attackers.
        public List<Attacker> GetAttackers()
        {
            return this.Attackers;
        }
    }
}

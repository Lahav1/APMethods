using APMethods.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APMethods.Levels
{
    class MediumLevel : Level
    {
        Random rnd;
        List<Obstacle> obstacles;
        List<Enemy> enemies;
        List<Attacker> Attackers;

        public MediumLevel(Board board, Player player)
        {
            this.rnd = new Random();
            this.obstacles = new List<Obstacle>();
            this.enemies = new List<Enemy>();
            this.Attackers = new List<Attacker>();
            this.GenerateLevel(board, player);
        }

        public void GenerateLevel(Board board, Player player)
        {
            int width = board.GetWidth();
            int height = board.GetHeight();

            // Generate obstacles
            for (int i = 0; i < width * height / 90; i++)
            {
                int px = this.rnd.Next(1, width - 1);
                int py = this.rnd.Next(1, height - 1);
                this.obstacles.Add(new Obstacle(px, py));
            }

            // Generate enemies
            for (int i = 0; i < Math.Max(3, width * height / 300); i++)
            {
                int x = 0;
                int y = 0;
                do
                {
                    x = this.rnd.Next(1, width - 1);
                } while (this.obstacles.Any(e => e.GetX() == x));

                do
                {
                    y = this.rnd.Next(1, height - 1);
                } while (this.obstacles.Any(e => e.GetY() == y));

                int iter = i % 2;
                Enemy e = new Enemy(x, y, player, this.obstacles);
                e.SetChasingStrategy(new BasicChaser());
                this.enemies.Add(e);
                switch (iter)
                {
                    case 0:
                        this.Attackers.Add(new FlamingAttacker(e));
                        break;
                    case 1:
                        this.Attackers.Add(new FreezingAttacker(e));
                        break;
                }
            }
        }

        public List<Obstacle> GetObstacles()
        {
            return this.obstacles;
        }

        public List<Enemy> GetEnemies()
        {
            return this.enemies;
        }

        public List<Attacker> GetAttackers()
        {
            return this.Attackers;
        }
    }
}

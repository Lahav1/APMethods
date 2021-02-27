using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Levels
{
    class EasyLevel : Level
    {
        Random rnd;
        List<Obstacle> obstacles;

        public EasyLevel(Board board)
        {
            this.rnd = new Random();
            this.obstacles = new List<Obstacle>();
            this.GenerateLevel(board);
        }

        public void GenerateLevel(Board board)
        {
            int width = board.Width;
            int height = board.Height;
            for (int i = 0; i < ((width * height) / 65); i++)
            {
                int px = this.rnd.Next(1, width - 1);
                int py = this.rnd.Next(1, height - 1);
                this.obstacles.Add(new Obstacle(px, py));
            } 
        }

        public List<Obstacle> GetObstacles()
        {
            return this.obstacles;
        }
    }
}

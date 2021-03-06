using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Levels
{
    interface Level
    {
        public void GenerateLevel(Board board, Player player);
        public List<Obstacle> GetObstacles();
        public List<Enemy> GetEnemies();
        public List<Attacker> GetAttackers();
    }
}

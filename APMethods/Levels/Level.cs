using APMethods.GameBoard;
using System.Collections.Generic;

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

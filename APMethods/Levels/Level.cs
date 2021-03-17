using APMethods.GameBoard;
using System.Collections.Generic;

namespace APMethods.Levels
{
    interface Level
    {
        // Generates a level.
        public void GenerateLevel(Board board, Player player);

        // Get the generate level obstacles.
        public List<Obstacle> GetObstacles();

        // Get the generate level enemies.
        public List<Enemy> GetEnemies();

        // Get the generate level attackers.
        public List<Attacker> GetAttackers();
    }
}

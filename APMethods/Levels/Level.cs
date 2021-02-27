using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Levels
{
    interface Level
    {
        public void GenerateLevel(Board board);
        public List<Obstacle> GetObstacles();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class AdvancedChaser : ChasingStrategy
    {
        Random rnd;

        public AdvancedChaser()
        {
            this.rnd = new Random();
        }

        public void ChasingAlgorithm(Enemy enemy, Board board, Player player)
        {
            Random r = new Random();
            double heading = 0;
            if (r.Next(8) < 2)
            {
                heading = r.Next(360);
            } 
            else
            {
                double lon2 = enemy.GetX();
                double lat2 = enemy.GetY();
                double lon = player.GetX();
                double lat = player.GetY();

                double teta1 = ToRad(lat);
                double teta2 = ToRad(lat2);
                double delta1 = ToRad(lat2 - lat);
                double delta2 = ToRad(lon2 - lon);

                //==================Heading Formula Calculation================//
                Random r1 = new Random();

                double y = Math.Sin(delta2) * Math.Cos(teta2);
                double x = Math.Cos(teta1) * Math.Sin(teta2) - Math.Sin(teta1) * Math.Cos(teta2) * Math.Cos(delta2);
                double brng = Math.Atan2(y, x);
                brng = ToDegrees(brng);     // radians to degrees
                brng = (((int)brng + 360) % 360);

                heading = brng;
            }

            if (heading > 337.5 && heading <= 22.5)
            {
                enemy.MoveUp(board);
            }
            else if (heading > 22.5 && heading <= 67.5)
            {
                enemy.MoveUp(board);
                enemy.MoveLeft(board);
            }
            else if (heading > 67.5 && heading <= 112.5)
            {
                enemy.MoveLeft(board);
            }
            else if (heading > 112.5 && heading <= 157.5)
            {
                enemy.MoveLeft(board);
                enemy.MoveDown(board);
            }
            else if (heading > 157.5 && heading <= 202.5)
            {
                enemy.MoveDown(board);
            }
            else if (heading > 202.5 && heading <= 247.5)
            {
                enemy.MoveDown(board);
                enemy.MoveRight(board);
            }
            else if (heading > 247.5 && heading <= 292.5)
            {
                enemy.MoveRight(board);
            }
            else if (heading > 292.5 && heading <= 337.5)
            {
                enemy.MoveUp(board);
                enemy.MoveRight(board);
            }
        }

        private static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        private static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        private static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }
    }
}

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

        public void ChasingAlgorithm(Enemy enemy, Board board)
        {
            String[] direction = { "Up", "Down", "Right", "Left", "Up-Right", "Up-Left", "Down-Right", "Down-Left" };
            int i = this.rnd.Next(8);
            switch (direction[i])
            {
                case "Up":
                    enemy.MoveUp(board);
                    break;
                case "Down":
                    enemy.MoveDown(board);
                    break;
                case "Right":
                    enemy.MoveRight(board);
                    break;
                case "Left":
                    enemy.MoveLeft(board);
                    break;
                case "Up-Right":
                    enemy.MoveUp(board);
                    enemy.MoveRight(board);
                    break;
                case "Up-Left":
                    enemy.MoveUp(board);
                    enemy.MoveLeft(board);
                    break;
                case "Down-Right":
                    enemy.MoveDown(board);
                    enemy.MoveRight(board);
                    break;
                case "Down Left":
                    enemy.MoveDown(board);
                    enemy.MoveLeft(board);
                    break;
            }
        }
    }
}

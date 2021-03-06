using APMethods.GameBoard;
using System;

namespace APMethods
{
    class BasicChaser : ChasingStrategy
    {
        Random rnd;

        public BasicChaser()
        {
           this.rnd = new Random();
        }

        public void Chase(Enemy enemy, Board board, Player player)
        {
            String[] direction = { "Up", "Down", "Right", "Left" };
            int i = this.rnd.Next(4);
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
            }
        }
    }
}

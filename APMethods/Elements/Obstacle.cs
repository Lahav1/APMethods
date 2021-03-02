using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Obstacle : Drawable
    {
        int xPos;
        int yPos;
        char symbol;

        public Obstacle(int x, int y)
        {
            this.xPos = x;
            this.yPos = y;
            this.symbol = '#';
        }

        public void DrawOn(Board board)
        {
            board.Emplace(this.xPos, this.yPos, this.symbol);
        }

        public int GetX()
        {
            return this.xPos;
        }

        public int GetY()
        {
            return this.yPos;
        }
    }
}

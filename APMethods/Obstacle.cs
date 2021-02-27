using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Obstacle : Drawable
    {
        int xPos;
        int yPos;

        public Obstacle(int x, int y)
        {
            this.xPos = x;
            this.yPos = y;
        }

        public void DrawOn(Board board)
        {
            board.DrawCell(this.xPos, this.yPos, '#');
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

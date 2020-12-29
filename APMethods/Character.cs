using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Character : Drawable
    {
        protected int xPos;
        protected int yPos;
        protected char symbol;
        protected int health;

        public Character(int x, int y)
        {
            this.health = 100;
            this.xPos = x;
            this.yPos = y;
        }

        public void DrawOn(Board board)
        {
            board.DrawCell(this.xPos, this.yPos, this.symbol);
        }
    }
}

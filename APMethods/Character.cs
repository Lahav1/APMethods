using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    abstract class Character : Drawable
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

        public virtual void MoveUp(Board board)
        {
            if (this.yPos > 1)
            {
                this.yPos = this.yPos - 1;
            }
        }

        public virtual void MoveDown(Board board)
        {
            if (this.yPos < board.Height)
            {
                this.yPos = this.yPos + 1;
            }
        }

        public void MoveLeft(Board board)
        {
            if (this.xPos > 1)
            {
                this.xPos = this.xPos - 1;
            }
        }

        public void MoveRight(Board board)
        {
            if (this.xPos < board.Width)
            {
                this.xPos = this.xPos + 1;
            }
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

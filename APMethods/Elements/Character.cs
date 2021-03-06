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
        private List<Obstacle> obstacles;

        public Character(int x, int y, List<Obstacle> obstacles)
        {
            this.xPos = x;
            this.yPos = y;
            this.obstacles = obstacles;
        }

        public void DrawOn(Board board)
        {
            board.Emplace(this.xPos, this.yPos, this.symbol);
        }

        public virtual void MoveUp(Board board)
        {
            if (this.yPos > 1 && !this.DoesObstacleExist(this.xPos, this.yPos - 1))
            {
                this.yPos = this.yPos - 1;
            }
        }

        public virtual void MoveDown(Board board)
        {
            if (this.yPos < board.Height && !this.DoesObstacleExist(this.xPos, this.yPos + 1))
            {
                this.yPos = this.yPos + 1;
            }
        }

        public void MoveLeft(Board board)
        {
            if (this.xPos > 1 && !this.DoesObstacleExist(this.xPos - 1, this.yPos))
            {
                this.xPos = this.xPos - 1;
            }
        }

        public void MoveRight(Board board)
        {
            if (this.xPos < board.Width && !this.DoesObstacleExist(this.xPos + 1, this.yPos))
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


        public bool DoesObstacleExist(int x, int y)
        {
            foreach (Obstacle obstacle in this.obstacles)
            {
                if (obstacle.GetX() == x && obstacle.GetY() == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetObstacles(List<Obstacle> o)
        {
            this.obstacles = o;
        }
    }
}

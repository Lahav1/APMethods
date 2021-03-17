using APMethods.GameBoard;
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

        // A character constructor.
        public Character(int x, int y, List<Obstacle> obstacles)
        {
            this.xPos = x;
            this.yPos = y;
            this.obstacles = obstacles;
        }

        // Draws the character on board.
        public void DrawOn(Board board)
        {
            board.Emplace(this.xPos, this.yPos, this.symbol);
        }

        // Move character up.
        public virtual void MoveUp(Board board)
        {
            if (this.yPos > 1 && !this.DoesObstacleExist(this.xPos, this.yPos - 1))
            {
                this.yPos = this.yPos - 1;
            }
        }

        // Move character down.
        public virtual void MoveDown(Board board)
        {
            if (this.yPos < board.GetHeight() && !this.DoesObstacleExist(this.xPos, this.yPos + 1))
            {
                this.yPos = this.yPos + 1;
            }
        }

        // Move character left.
        public void MoveLeft(Board board)
        {
            if (this.xPos > 1 && !this.DoesObstacleExist(this.xPos - 1, this.yPos))
            {
                this.xPos = this.xPos - 1;
            }
        }

        // Move character right.
        public void MoveRight(Board board)
        {
            if (this.xPos < board.GetWidth() && !this.DoesObstacleExist(this.xPos + 1, this.yPos))
            {
                this.xPos = this.xPos + 1;
            }
        }

        // Get X position of character.
        public int GetX()
        {
            return this.xPos;
        }
        
        // Get Y position of character.
        public int GetY()
        {
            return this.yPos;
        }


        // Checks if there is an obstacle on board on position x, y.
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

        // Sets the obstacle member of character.
        public void SetObstacles(List<Obstacle> o)
        {
            this.obstacles = o;
        }
    }
}

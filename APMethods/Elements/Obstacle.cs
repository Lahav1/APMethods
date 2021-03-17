using APMethods.GameBoard;

namespace APMethods
{
    // A class that represents an obstacle on the board that no character can step on.
    class Obstacle : Drawable
    {
        int xPos;
        int yPos;
        char symbol;

        // Obstacle constructor.
        public Obstacle(int x, int y)
        {
            this.xPos = x;
            this.yPos = y;
            this.symbol = '#';
        }

        // Draws the obstacle on the screen.
        public void DrawOn(Board board)
        {
            board.Emplace(this.xPos, this.yPos, this.symbol);
        }

        // Get the X position of the obstacle.
        public int GetX()
        {
            return this.xPos;
        }

        // Get the Y position of the obstacle.
        public int GetY()
        {
            return this.yPos;
        }
    }
}

using APMethods.GameBoard;

namespace APMethods
{
    // Interface for objects that can be drawn.
    interface Drawable
    {
        // Draw an obstacle on board.
        void DrawOn(Board board);
    }
}

using APMethods.GameBoard;

namespace APMethods
{
    interface ChasingStrategy
    {
        public void Chase(Enemy enemy, Board board, Player player);
    }
}

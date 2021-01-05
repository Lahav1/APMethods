using System;

namespace APMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(50, 20);
            Game game = new Game(board);
            game.Run();
        }
    }
}

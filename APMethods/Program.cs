using System;

namespace APMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Screens.OpenScreen();
            int difficulty = Screens.SelectDifficulty(25, 10);
            ConsoleBoard board = new ConsoleBoard(20, 50);
            Game game = new Game(board, difficulty);
            game.Run();
            Screens.Finish();
        }
    }
}

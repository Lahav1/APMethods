﻿using System;

namespace APMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Screens.OpenScreen();
            Board board = new Board(20, 50);
            Game game = new Game(board);
            game.Run();
        }
    }
}

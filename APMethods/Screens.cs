using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace APMethods
{
    class Screens
    {
        public static void OpenScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Resources.OpenScreenString);
            Thread.Sleep(2200);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Properties.Resources.OpenScreenString);
            Thread.Sleep(400);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(Properties.Resources.OpenScreenString);
            Thread.Sleep(400);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(800);
        }

        public static void EndScreen(int x, int y, int score)
        {
            x -= 14;
            y -= 2;
            x = Math.Max(0, x);
            y = Math.Max(0, y);
            Console.SetCursorPosition(x, y);
            Console.Write(new String('*', 29));
            Console.SetCursorPosition(x, y + 1);
            Console.Write("*                           *");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("*         GAME OVER         *");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("*                           *");
            Console.SetCursorPosition(x, y + 4);
            Console.Write($"*     Your score is:        *");
            Console.SetCursorPosition(x + 21, y + 4);
            Console.Write(score);
            Console.SetCursorPosition(x, y + 5);
            Console.Write("*                           *");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine(new String('*', 29));
        }
    }
}

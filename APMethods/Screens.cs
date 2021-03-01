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

        public static int SelectDifficulty(int x, int y)
        {
            x -= 14;
            y -= 2;
            x = Math.Max(0, x);
            y = Math.Max(0, y);
            Console.SetCursorPosition(x, y);
            Console.Write(new String('*', 45));
            Console.SetCursorPosition(x, y + 1);
            Console.Write("*");
            Console.Write(new string(' ', 43));
            Console.Write("*");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("*         Please choose difficulty          *");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("*");
            Console.Write(new string(' ', 43));
            Console.Write("*"); Console.SetCursorPosition(x, y + 4);
            Console.Write($"*      1 - Easy, 2 - Medium, 3 - Hard       *");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("*");
            Console.Write(new string(' ', 43));
            Console.Write("*");
            Console.SetCursorPosition(x, y + 6);
            Console.Write("*");
            Console.Write(new string(' ', 43));
            Console.Write("*");
            Console.SetCursorPosition(x, y + 7);
            Console.Write("*");
            Console.Write(new string(' ', 43));
            Console.Write("*");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine(new String('*', 45));
            Console.SetCursorPosition(x + 22, y + 6);
            int difficulty = int.Parse(Console.ReadLine());
            while (difficulty != 1 && difficulty != 2 && difficulty != 3)
            {
                Console.SetCursorPosition(x + 22, y + 6);
                Console.Write(new string(' ', 5));
                Console.SetCursorPosition(x + 22, y + 6);
                difficulty = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            return difficulty;
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
            Console.SetCursorPosition(0, 0);
        }
    }
}

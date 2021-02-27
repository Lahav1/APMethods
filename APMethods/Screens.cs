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
    }
}

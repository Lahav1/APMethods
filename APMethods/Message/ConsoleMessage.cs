using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Message
{
    class ConsoleMessage : Message
    {
        int x;
        int y;
        string text;

        // Constructs a message that appears on console.
        public ConsoleMessage(int x, int y, string text)
        {
            this.x = x;
            this.y = y;
            this.text = text;
        }

        public void Display()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    abstract class Indicator
    {
        protected int value;
        int xPos;
        int yPos;
        string title; 

        public Indicator(int value, int x, int y, string title)
        {
            this.value = value;
            this.xPos = x;
            this.yPos = y;
            this.title = title;
        }
        
        // Display indicator on screen.
        public void Display()
        {
            Console.SetCursorPosition(this.xPos + this.title.Length + 1, 0);
            Console.Write(new String(' ', 4));
            Console.SetCursorPosition(this.xPos, this.yPos);
            Console.Write(this.title + ": " + this.value);
        }
    }
}

using APMethods.GameBoard;
using System;
using System.Collections.Generic;

namespace APMethods
{
    class ConsoleBoard : Board
    {
        char[,] grid;
        List<Drawable> elements;
        int width;
        int height;

        public ConsoleBoard(int height, int width)
        {
            this.width = width;
            this.height = height;
            this.grid = this.InitGrid(width, height);
            this.elements = new List<Drawable>();
        }

        // Initialize the grid's frame.
        public char[,] InitGrid(int width, int height)
        {
            // initialize the grid frame
            char[,] g = new char[height + 2, width + 2];
            for (int i = 0; i < height + 2; i++)
            {
                for (int j = 0; j < width + 2; j++)
                {
                    g[i, j] = ' ';
                }
            }
            g[0, 0] = '╔';
            g[0, width + 1] = '╗';
            g[height + 1, 0] = '╚';
            g[height + 1, width + 1] = '╝';
            for (int i = 1; i < width + 1; i++)
            {
                g[0, i] = '═';
            }
            for (int i = 1; i < height + 1; i++)
            {
                g[i, 0] = '║';
                g[i, width + 1] = '║';
            }
            for (int i = 1; i < width + 1; i++)
            {
                g[height + 1, i] = '═';
            }
            return g;
        }

        // Emplace an element on the board.
        public void Emplace(int x, int y, char symbol)
        {
            this.grid[y, x] = symbol;
        }

        // Draw board on console.
        public void Draw(List<Drawable> elements)
        {
            Console.SetCursorPosition(0, 1);
            this.grid = this.InitGrid(this.width, this.height);
            foreach (var element in elements)
            {
                element.DrawOn(this);
            }
            int rows = this.grid.GetLength(0);
            int cols = this.grid.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0}", this.grid[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        // Return the board's height.
        public int GetHeight()
        {
            return this.height;
        }

        // Return the board's width.
        public int GetWidth()
        {
            return this.width;
        }
    }
}

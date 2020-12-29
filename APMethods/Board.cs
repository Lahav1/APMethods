using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;

namespace APMethods
{
    class Board
    {
        char[,] grid;
        List<Drawable> elements;
        int width;
        int height;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.grid = this.InitGrid(width, height);
            this.elements = new List<Drawable>();
        }

        private char[,] InitGrid(int width, int height)
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

        public void AddElement(Drawable d)
        {
            this.elements.Add(d);
        }

        public void DrawCell(int x, int y, char symbol)
        {
            this.grid[y, x] = symbol;
        }

        public void Draw()
        {
            this.grid = this.InitGrid(this.width, this.height);
            foreach (var element in this.elements)
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
    }
}

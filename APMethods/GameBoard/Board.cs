using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.GameBoard
{
    interface Board
    {
        public char[,] InitGrid(int width, int height);
        public void Emplace(int x, int y, char symbol);
        public void Draw(List<Drawable> elements);
        public int GetHeight();
        public int GetWidth();
    }
}

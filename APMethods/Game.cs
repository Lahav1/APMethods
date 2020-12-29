using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace APMethods
{
    class Game
    {
        Board board;
        List<Drawable> elements;
        Player player;

        public Game(Board board)
        {
            this.board = board;
            this.elements = new List<Drawable>();
            this.player = new Player(8, 19);
            this.board.AddElement(this.player);
            this.elements.Add(this.player);
            Drawable e1 = new Enemy(9, 14);
            this.board.AddElement(e1);
            this.elements.Add(e1);
            Drawable e2 = new Enemy(5, 7);
            this.board.AddElement(e2);
            this.elements.Add(e2);
            Drawable e3 = new Enemy(2, 3);
            this.board.AddElement(e3);
            this.elements.Add(e3);
        }

        public void HandleKeyPress(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                this.player.MoveUp(this.board);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                this.player.MoveDown(this.board);
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                this.player.MoveLeft(this.board);
            }
            else if (key == ConsoleKey.RightArrow)
            {
                this.player.MoveRight(this.board);
            }
        }

        public void run()
        {
            Console.CursorVisible = false;
            this.board.Draw();
            ConsoleKey key = 0;
            do
            {
                this.HandleKeyPress(key);
                while (!Console.KeyAvailable)
                {
                    this.board.Draw();
                }
            } while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape);
        }
    }
}

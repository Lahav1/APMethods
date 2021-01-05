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
        List<Enemy> enemies;
        ScoreIndicator scoreIndicator;
        HealthIndicator healthIndicator;

        public Game(Board board)
        {
            this.board = board;
            this.elements = new List<Drawable>();
            this.player = new Player(8, 19);
            this.enemies = new List<Enemy>();
            this.elements.Add(this.player);
            Enemy e1 = new Enemy(9, 14);
            this.elements.Add(e1);
            this.enemies.Add(e1);
            Enemy e2 = new Enemy(5, 7);
            this.elements.Add(e2);
            this.enemies.Add(e2);
            Enemy e3 = new Enemy(2, 3);
            this.elements.Add(e3);
            this.enemies.Add(e3);
            this.scoreIndicator = new ScoreIndicator(10, 0, this.player);
            this.healthIndicator = new HealthIndicator(30, 0, this.player);
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

        public void Render()
        {
            this.board.Draw(this.elements);
            this.scoreIndicator.Display();
            this.healthIndicator.Display();
        }

        public void Run()
        {
            Console.CursorVisible = false;
            this.Render();
            ConsoleKey key = 0;
            do
            {
                this.HandleKeyPress(key);
                while (!Console.KeyAvailable)
                {
                    // [todo: move all enemies].
                    this.Render();
                }
            } while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape);
        }
    }
}

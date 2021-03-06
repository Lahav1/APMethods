using APMethods.Levels;
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
        List<Attacker> attackers;
        List<Obstacle> obstacles;
        ScoreIndicator scoreIndicator;
        HealthIndicator healthIndicator;
        bool moveFlag;

        public Game(Board board, int difficulty)
        {
            this.moveFlag = true;
            this.board = board;
            this.elements = new List<Drawable>();
            this.player = new Player(8, 19, this.obstacles);

            LevelFactory factory = new LevelFactory(this.board, this.player);
            Level lvl = factory.GetLevel(difficulty);
            this.obstacles = lvl.GetObstacles();
            this.enemies = lvl.GetEnemies();
            this.attackers = lvl.GetAttackers();
            this.elements.AddRange(this.enemies);
            this.elements.AddRange(this.obstacles);
            this.elements.Add(this.player);
            this.player.SetObstacles(this.obstacles);
            
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
            int iteration = 0;
            int timeSinceLastHit = 0;
            do
            {
                this.HandleKeyPress(key);
                while (!Console.KeyAvailable && this.player.Health != 0)
                {
                    if (iteration % 30 == 0)
                    {
                        this.player.IncreaseScore(1);
                    }
                    if(timeSinceLastHit % 90 == 0)
                    {
                        Console.SetCursorPosition(0, this.board.Height + 4);
                        Console.Write(new String(' ', 100));
                    }
                    if(moveFlag = !moveFlag)
                    {
                        for (int i = 0; i < this.enemies.Count; i++)
                        {
                            this.enemies[i].Move(this.board, this.player);
                            bool isHit = this.player.CheckHit(this.enemies[i]);
                            if (isHit)
                            {
                                timeSinceLastHit = 0;
                                Console.SetCursorPosition(0, this.board.Height + 4);
                                Console.Write(new String(' ', 100));
                                Console.SetCursorPosition(0, this.board.Height + 4);
                                this.attackers[i].Attack(0, this.board.Height + 4, this.player);
                            }
                        }
                    }

                    iteration++;
                    timeSinceLastHit++;
                    this.Render();
                }
                // game over message
                if (this.player.Health == 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write(new String(' ', 100));
                    Console.SetCursorPosition(0, this.board.Height + 4);
                    Console.Write(new String(' ', 100));
                    Screens.EndScreen(this.board.Width / 2, this.board.Height / 2, this.player.Score);
                }
            } while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape);
        }
    }
}

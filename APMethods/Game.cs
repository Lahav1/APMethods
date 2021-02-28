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

        public Game(Board board, int difficulty)
        {
            this.board = board;
            this.elements = new List<Drawable>();
            this.enemies = new List<Enemy>();
            this.attackers = new List<Attacker>();

            LevelFactory factory = new LevelFactory(this.board);
            Level lvl = factory.GetLevel(difficulty);
            this.obstacles = lvl.GetObstacles();
            this.elements.AddRange(this.obstacles);
            
            this.player = new Player(8, 19, this.obstacles);
            this.elements.Add(this.player);

            Enemy e1 = new Enemy(9, 14, this.player, this.obstacles);
            e1.SetChasingStrategy(new BasicChaser());
            this.elements.Add(e1);
            this.enemies.Add(e1);
            Attacker a1 = new FlamingAttacker(e1);
            this.attackers.Add(a1);

            Enemy e2 = new Enemy(5, 7, this.player, this.obstacles);
            e2.SetChasingStrategy(new BasicChaser());
            this.elements.Add(e2);
            this.enemies.Add(e2);
            Attacker a2 = new FreezingAttacker(e2);
            this.attackers.Add(a2);

            Enemy e3 = new Enemy(2, 3, this.player, this.obstacles);
            e3.SetChasingStrategy(new BasicChaser());
            this.elements.Add(e3);
            this.enemies.Add(e3);
            Attacker a3 = new FlamingAttacker(new FreezingAttacker(e3));
            this.attackers.Add(a3);

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
                while (!Console.KeyAvailable && this.player.GetHealth() != 0)
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
                    iteration++;
                    timeSinceLastHit++;
                    this.Render();
                }
                // game over message
                if (this.player.GetHealth() == 0)
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

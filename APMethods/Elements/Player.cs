using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Player : Character, HealthObservable, ScoreObservable
    {
        public int Score { get; set; }
        public int Health { get; set; }
        List<Observer> healthObservers;
        List<Observer> scoreObservers;

        public Player(int x, int y, List<Obstacle> obstacles) : base(x, y, obstacles)
        {
            this.symbol = 'P';
            this.Score = 0;
            this.Health = 100;
            this.healthObservers = new List<Observer>();
            this.scoreObservers = new List<Observer>();
        }

        public void SubscribeToHealth(Observer o)
        {
            this.healthObservers.Add(o);
        }

        public void UnsubscribeFromHealth(Observer o)
        {
            this.healthObservers.Remove(o);
        }

        public void SubscribeToScore(Observer o)
        {
            this.scoreObservers.Add(o);
        }

        public void UnsubscribeFromScore(Observer o)
        {
            this.scoreObservers.Remove(o);
        }

        public void IncreaseScore(int points)
        {
            this.Score += points;
            this.NotifyScore(this.Score);
        }

        public void DecreaseHealth(int healthPoints)
        {
            this.Health -= healthPoints;
            if (this.Health < 0)
            {
                this.Health = 0;
            }
            this.NotifyHealth(this.Health);
        }

        public void NotifyHealth(int payload)
        {
            foreach (Observer o in this.healthObservers)
            {
                o.Update(payload);
            }
        }

        public void NotifyScore(int payload)
        {
            foreach (Observer o in this.scoreObservers)
            {
                o.Update(payload);
            }
        }

        public bool CheckHit(Enemy enemy)
        {
            return (this.xPos == enemy.GetX() && this.yPos == enemy.GetY());
        }
    }
}

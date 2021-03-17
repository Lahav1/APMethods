using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Player : Character, HealthObservable, ScoreObservable
    {
        public int Score { get; set; }      // The player's score.
        public int Health { get; set; }     // The player's health.
        List<Observer> healthObservers;     // A list of all player's health observers.
        List<Observer> scoreObservers;      // A list of all player's scoreObservers.

        // Player constructor.
        public Player(int x, int y, List<Obstacle> obstacles) : base(x, y, obstacles)
        {
            this.symbol = 'P';
            this.Score = 0;
            this.Health = 100;
            this.healthObservers = new List<Observer>();
            this.scoreObservers = new List<Observer>();
        }

        // Subscribe to health.
        public void SubscribeToHealth(Observer o)
        {
            this.healthObservers.Add(o);
        }

        // Unsubscribe to health.
        public void UnsubscribeFromHealth(Observer o)
        {
            this.healthObservers.Remove(o);
        }

        // Subscribe to score.
        public void SubscribeToScore(Observer o)
        {
            this.scoreObservers.Add(o);
        }

        // Unubscribe to health.
        public void UnsubscribeFromScore(Observer o)
        {
            this.scoreObservers.Remove(o);
        }

        // Increase the player's score.
        public void IncreaseScore(int points)
        {
            this.Score += points;
            this.NotifyScore(this.Score);
        }

        // Decrease the player's health.
        public void DecreaseHealth(int healthPoints)
        {
            this.Health -= healthPoints;
            if (this.Health < 0)
            {
                this.Health = 0;
            }
            this.NotifyHealth(this.Health);
        }

        // Update all observers that health changed.
        public void NotifyHealth(int payload)
        {
            foreach (Observer o in this.healthObservers)
            {
                o.Update(payload);
            }
        }

        // Update all observers that score changed.
        public void NotifyScore(int payload)
        {
            foreach (Observer o in this.scoreObservers)
            {
                o.Update(payload);
            }
        }

        // Check if the enemy hit player.
        public bool CheckHit(Enemy enemy)
        {
            return (this.xPos == enemy.GetX() && this.yPos == enemy.GetY());
        }
    }
}

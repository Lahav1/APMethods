using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class Player : Character, HealthObservable, ScoreObservable
    {
        public int Score { get; set; }
        List<Observer> healthObservers;
        List<Observer> scoreObservers;

        public Player(int x, int y) : base(x, y)
        {
            this.Score = 0;
            this.symbol = 'P';
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

        public override void MoveUp(Board board)
        {
            if (this.yPos > 1)
            {
                this.yPos = this.yPos - 1;
            }
        }

        public override void MoveDown(Board board)
        {
            if (this.yPos < board.Height)
            {
                this.yPos = this.yPos + 1;
            }
        }

        public void IncreaseScore(int points)
        {
            this.Score += points;
            this.NotifyScore(this.Score);
        }

        public void DecreaseHealth(int healthPoints)
        {
            this.health -= healthPoints;
            if (this.health < 0)
            {
                this.health = 0;
            }
            this.NotifyHealth(this.health);
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

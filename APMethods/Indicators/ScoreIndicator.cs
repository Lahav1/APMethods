using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class ScoreIndicator : Indicator, Observer
    {
        public ScoreIndicator(int x, int y, ScoreObservable player) : base(0, x, y, "Score")
        {
            // subscribe to player's score parameter.
            player.SubscribeToScore(this);
        }

        public void Update(int payload)
        {
            this.value = payload;
        }
    }
}

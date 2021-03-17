using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class HealthIndicator : Indicator, Observer
    {
        public HealthIndicator(int x, int y, HealthObservable player) : base(100, x, y, "Health")
        {
            // subscribe to player's health parameter.
            player.SubscribeToHealth(this);
        }

        public void Update(int payload)
        {
            this.value = payload;
        }
    }
}

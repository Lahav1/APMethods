using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    class HealthIndicator : Indicator, Observer
    {
        public HealthIndicator(int x, int y, HealthObservable player) : base(100, x, y, "Health")
        {
            player.SubscribeToHealth(this);
        }

        public void Update(int payload)
        {
            this.value = payload;
        }
    }
}

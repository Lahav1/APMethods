using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface HealthObservable
    {
        public void SubscribeToHealth(Observer o);
        public void UnsubscribeFromHealth(Observer o);
        public void NotifyHealth(int payload);
    }
}

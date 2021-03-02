using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods
{
    interface ScoreObservable
    {
        public void SubscribeToScore(Observer o);
        public void UnsubscribeFromScore(Observer o);
        public void NotifyScore(int payload);
    }
}
